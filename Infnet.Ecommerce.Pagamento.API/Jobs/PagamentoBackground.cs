using Infnet.Ecommerce.Pagamento.Dominio.Repositorios.Mensagem;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using Infnet.Ecommerce.Pagamento.Dominio.Repositorios;

namespace Infnet.Ecommerce.Pagamento.API.Jobs
{
    public class PagamentoBackground : BackgroundService
    {
        private readonly ILogger<PagamentoBackground> logger;
        private readonly IServiceProvider provider;

        public PagamentoBackground(ILogger<PagamentoBackground> logger,  IServiceProvider serviceProvider)
        {
            this.logger = logger;
            this.provider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            var factory = new ConnectionFactory() { HostName = "localhost", Port = 5672, UserName = "guest", Password = "guest" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "ecommerce-pagamento",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var pagamentoMensagem = JsonSerializer.Deserialize<PagamentoMensagem>(message);

                    Console.WriteLine("Mensagem recebida: {0}", message);

                    Dominio.Entidades.Pagamento pagamento = new Dominio.Entidades.Pagamento();
                    pagamento.CestaId = pagamentoMensagem.CestaId;
                    pagamento.UsuarioId = pagamentoMensagem.UsuarioId;
                    pagamento.ValorTotal = pagamentoMensagem.ValorTotal;
                    pagamento.Parcelas = pagamentoMensagem.Parcelas;
                    using (var scope = provider.CreateScope())
                    {
                        var pagamentoRepositorio = scope.ServiceProvider.GetRequiredService<IPagamentoRepositorio>();
                        var carrinhoRepositorio = scope.ServiceProvider.GetRequiredService<ICarrinhoRepositorio>();

                        pagamentoRepositorio.Salvar(pagamento);
                        carrinhoRepositorio.AtualizaStatus(pagamentoMensagem.CestaId, "Fechada");
                    }

                    await Task.Yield();

                };
                channel.BasicConsume(queue: "ecommerce-pagamento",
                                     autoAck: true,
                                     consumer: consumer);

                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(1000, stoppingToken);
                }

            }
        }
    }
}
