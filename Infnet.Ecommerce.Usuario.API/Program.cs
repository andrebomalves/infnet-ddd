
using Infnet.Ecommerce.Usuario.Aplicacao.Usuario;
using Infnet.Ecommerce.Usuario.Aplicacao.Usuario.Interfaces;
using Infnet.Ecommerce.Usuario.Dominio.Repositorios;
using Infnet.Ecommerce.Usuario.Dominio.Servicos;
using Infnet.Ecommerce.Usuario.Dominio.Servicos.Interfaces;
using Infnet.Ecommerce.Usuario.Infra.Contexto;
using Infnet.Ecommerce.Usuario.Infra.Repositorios;

namespace Infnet.Ecommerce.Usuario.API
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

            builder.Services.AddAutoMapper(typeof(Infnet.Ecommerce.Usuario.Aplicacao.Usuario.Profiles.UsuarioProfile));

            builder.Services.AddScoped<IUsuarioRespositorio, Infra.Repositorios.UsuarioRepositorio>();
            builder.Services.AddScoped<IUsuarioServico, UsuarioServico>();
            builder.Services.AddScoped<IUsuarioAppServico, Aplicacao.Usuario.UsuarioAppServico>();


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
