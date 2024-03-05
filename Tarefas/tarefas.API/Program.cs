using System.Text.Json.Serialization;
using tarefa.Infra;
using tarefas.API.Infra.ApiConfigurations;
using tarefas.API.Infra.HealthCheck;
using tarefas.API.Infra.Ioc;
using Microsoft.EntityFrameworkCore;

namespace tarefas.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies(), ServiceLifetime.Scoped);

            var connection = configuration.GetConnectionString("SqlConnectionString");
            builder.Services.AddDbContext<TarefasSqlContext>(options => options.UseSqlServer(connection));

            builder.Services.ConfiguireMongoDb(configuration);
            MongoConfiguration.RegisterConfigurations();
            builder.Services.AddDependencies(configuration);

            builder.Services
                .AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressMapClientErrors = false;
                })
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                );

            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHealthChecks().AddCheck<DbHealthCheck>("database_health_check");

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            app.MapHealthChecks("/health");

            app.Run();
        }
    }
    
}

