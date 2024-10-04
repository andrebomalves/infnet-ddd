
using EasyNetQ;
using Infnet.Ecommerce.Carrinho.Aplicacao.Cesta.Interfaces;
using Infnet.Ecommerce.Carrinho.Dominio.Repositorios;
using Infnet.Ecommerce.Carrinho.Dominio.Servicos;
using Infnet.Ecommerce.Carrinho.Dominio.Servicos.Interfaces;
using Infnet.Ecommerce.Carrinho.Infra.Contexto;
using System.Text.Json.Serialization;

namespace Infnet.Ecommerce.Carrinho.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IDataContext>(new DataContext(builder.Configuration.GetConnectionString("Default")));

            //builder.Services.AddSingleton<IBus>( RabbitHutch.CreateBus("host=localhost;port=5672;username=guest;password=guest;"));

            builder.Services.AddAutoMapper(typeof(Infnet.Ecommerce.Carrinho.Aplicacao.Cesta.Profiles.ItemCestaProfile));

            builder.Services.AddScoped<ICestaRepositorio, Infra.Repositorios.CestaRepositorio>();
            builder.Services.AddScoped<IUsuarioRepositorio, Infra.Repositorios.UsuarioRepositorio>();
            builder.Services.AddScoped<IProdutoRepositorio, Infra.Repositorios.ProdutoRepositorio>();
            builder.Services.AddScoped<IPagamentoRepositorio, Infra.Repositorios.PagamentoRepositorio>();

            builder.Services.AddScoped<ICestaServico, CestaServico>();
            builder.Services.AddScoped<ICestaAppServico, Aplicacao.Cesta.CestaAppServico>();

            builder.Services.AddHttpClient("Produto", client => {
                client.BaseAddress = new Uri(builder.Configuration.GetSection("API.Produto:BaseUrl").Value);
            });

            builder.Services.AddHttpClient("Usuario", client => {
                client.BaseAddress = new Uri(builder.Configuration.GetSection("API.Usuario:BaseUrl").Value);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.Services.GetService<IDataContext>().Init();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
