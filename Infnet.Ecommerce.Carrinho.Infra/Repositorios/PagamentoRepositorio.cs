using Infnet.Ecommerce.Carrinho.Dominio.Repositorios;
using Infnet.Ecommerce.Carrinho.Dominio.Repositorios.Messagem;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Infnet.Ecommerce.Carrinho.Infra.Repositorios
{
    public class PagamentoRepositorio : IPagamentoRepositorio
    {
        public PagamentoRepositorio()
        {
            
        }
        public void RegistrarPagamento(PagamentoMensagem pagamentoMensagem)
        {

            var factory = new ConnectionFactory() { HostName = "localhost",Port = 5672, UserName="guest",Password="guest" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "ecommerce-pagamento",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var message = JsonSerializer.Serialize(pagamentoMensagem);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "ecommerce-pagamento",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine("Mensagem enviada: {0}", message);
            }
        }
    }
}
