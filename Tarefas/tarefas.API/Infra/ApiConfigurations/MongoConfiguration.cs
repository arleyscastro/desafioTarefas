using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;

namespace tarefas.API.Infra.ApiConfigurations
{
    public static class MongoConfiguration
    {
        public static void RegisterConfigurations()
        {
            BsonSerializer.RegisterSerializer(new DecimalSerializer(BsonType.Decimal128));

            var pack = new ConventionPack()
            {
                new IgnoreExtraElementsConvention(true),
                new CamelCaseElementNameConvention(),
                new EnumRepresentationConvention(BsonType.String)
            };

            ConventionRegistry.Register("My Solution Conventions", pack, t => true);
        }
    }
}