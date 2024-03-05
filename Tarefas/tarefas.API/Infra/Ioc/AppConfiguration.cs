using tarefa.Infra;
using tarefa.Infra.Data.Repository;
using tarefas.Core.Application.Application.Implementation;
using tarefas.Core.Application.Application.Interface;
using tarefas.Core.Application.Service.Implementation;
using tarefas.Core.Application.Service.Interface;
using tarefas.Core.Domain.Interfaces;

namespace tarefas.API.Infra.Ioc
{
    public static class AppConfiguration
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<>();
            services.AddDbContext<TarefasSqlContext>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddScoped<IHistoricoTarefaRepository, HistoricoTarefaRepository>();
            services.AddScoped<IComentarioRepository, ComentarioRepository>();

            //Services
            services.AddScoped<IProjetosService, ProjetosService>();
            services.AddScoped<ITarefasService, TarefasService>(); 

            //Applications
            services.AddScoped<IProjetosApplication, ProjetosApplication>();
            services.AddScoped<ITarefasApplication, TarefasApplication>();

            services.ConfigureOptions(configuration);
            services.ConfigureHttpClients(configuration);

            services.AddControllersWithViews();
        }

        private static void ConfigureHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
        }

        public static IServiceCollection ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}