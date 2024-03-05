using MongoDB.Driver;

namespace tarefas.API.Infra.Ioc
{
    public static class MongoDBConfiguration
    {
        public static void ConfiguireMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(m =>
            {
                var connectionString = configuration["MongoDBConnectionString"];
                if (string.IsNullOrWhiteSpace(connectionString))
                    throw new Exception("O parâmetro MongoDBConnectionString não foi configurado");

                return new MongoClient(connectionString);
            });

            services.AddSingleton(m =>
            {
                var mongoDatabase = configuration["MongoDatabase"];

                if (string.IsNullOrWhiteSpace(mongoDatabase))
                    throw new Exception("O parâmetro MongoDatabase não foi configurado");

                var client = m.GetService<MongoClient>();
                return client.GetDatabase(mongoDatabase);
            });
        }
    }
}