
using Infnet.Ecommerce.Pagamento.API.Jobs;
using Infnet.Ecommerce.Pagamento.Dominio.Repositorios;
using Infnet.Ecommerce.Pagamento.Infra.Contexto;

namespace Infnet.Ecommerce.Pagamento.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IDataContext>(new DataContext(builder.Configuration.GetConnectionString("Default")));

            /*builder.Services.AddAutoMapper(typeof(Infnet.Ecommerce.Usuario.Aplicacao.Usuario.Profiles.UsuarioProfile));

            builder.Services.AddScoped<IUsuarioRespositorio, Infra.Repositorios.UsuarioRepositorio>();
            builder.Services.AddScoped<IUsuarioServico, UsuarioServico>();
            builder.Services.AddScoped<IUsuarioAppServico, Aplicacao.Usuario.UsuarioAppServico>(); */
            builder.Services.AddScoped<IPagamentoRepositorio, Infra.Repositorios.PagamentoRepositorio>();
            builder.Services.AddScoped<ICarrinhoRepositorio, Infra.Repositorios.CarrinhoRepositorio>();

            // https://learn.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-8.0&tabs=visual-studio
            builder.Services.AddHostedService<PagamentoBackground>();

            builder.Services.AddHttpClient("Carrinho", client => {
                client.BaseAddress = new Uri(builder.Configuration.GetSection("API.Carrinho:BaseUrl").Value);
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
