using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using ServicoProcessamento.Domain.Pesquisa;

namespace ServicoProcessamento.Infrastructure.Data.Migrations;

public static class MongoDbConfigurator
{
    public static void Configure()
    {
        BsonClassMap.RegisterClassMap<Pergunta>(cm =>
        {
            cm.AutoMap();
            cm.MapIdMember(p => p.Id);
            cm.MapMember(p => p.Descricao).SetIsRequired(true);
            cm.MapMember(p => p.Alternativas).SetIsRequired(true);
        });

        BsonClassMap.RegisterClassMap<Pesquisa>(cm =>
        {
            cm.AutoMap();
            cm.MapIdMember(p => p.Id);
            cm.MapMember(p => p.Codigo).SetIsRequired(true);
            cm.MapMember(p => p.Inicio).SetIsRequired(true);
            cm.MapMember(p => p.Fim).SetIsRequired(true);
            cm.MapMember(p => p.Ativa);
            cm.MapMember(p => p.Perguntas);
        });
    }
}