
using Infnet.Ecommerce.Produto.Aplicacao.Produto.Interfaces;
using Infnet.Ecommerce.Produto.Dominio.Repositorios;
using Infnet.Ecommerce.Produto.Dominio.Servicos;
using Infnet.Ecommerce.Produto.Dominio.Servicos.Interfaces;
using Infnet.Ecommerce.Produto.Infra.Contexto;

namespace Infnet.Ecommerce.Produto.API
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

            builder.Services.AddAutoMapper(typeof(Infnet.Ecommerce.Produto.Aplicacao.Produto.Profiles.ProdutoProfile));

            builder.Services.AddScoped<IProdutoRepositorio, Infra.Repositorios.ProdutoRepositorio>();
            builder.Services.AddScoped<IProdutoServico, ProdutoServico>();
            builder.Services.AddScoped<IProdutoAppServico, Aplicacao.Produto.ProdutoAppServico>(); 

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
