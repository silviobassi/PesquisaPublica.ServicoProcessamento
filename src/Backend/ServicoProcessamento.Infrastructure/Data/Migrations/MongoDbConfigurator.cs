using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using ServicoProcessamento.Domain.Pesquisa.Entities;

namespace ServicoProcessamento.Infrastructure.Data.Migrations;

public static class MongoDbConfigurator
{
    public static void Configure()
    {
        BsonClassMap.RegisterClassMap<Respondedor>(cm =>
        {
            cm.AutoMap();
            cm.MapIdMember(r => r.Id)
                .SetIdGenerator(CombGuidGenerator.Instance)
                .SetSerializer(new GuidSerializer(GuidRepresentation.Standard));
            cm.MapMember(r => r.Nome).SetIsRequired(true);
            cm.MapMember(r => r.Email).SetIsRequired(true);
            cm.MapMember(r => r.Idade).SetIsRequired(true);
        });

        BsonClassMap.RegisterClassMap<Alternativa>(cm =>
        {
            cm.AutoMap();
            cm.MapIdMember(c => c.Id)
                .SetIdGenerator(CombGuidGenerator.Instance)
                .SetSerializer(new GuidSerializer(GuidRepresentation.Standard));// Converte ObjectId para string
            cm.MapMember(a => a.Descricao).SetIsRequired(true);
            cm.MapMember(a => a.RespondedorIds)
                .SetSerializer(
                    new EnumerableInterfaceImplementerSerializer<List<Guid>>(
                        new GuidSerializer(GuidRepresentation.Standard)));
        });

        
        BsonClassMap.RegisterClassMap<Pergunta>(cm =>
        {
            cm.AutoMap();
            cm.MapIdMember(p => p.Id)
                .SetIdGenerator(CombGuidGenerator.Instance)
                .SetSerializer(new GuidSerializer(GuidRepresentation.Standard));
            cm.MapMember(p => p.Descricao).SetIsRequired(true);
            cm.MapMember(p => p.Alternativas).SetIsRequired(true);
        });

        BsonClassMap.RegisterClassMap<Pesquisa>(cm =>
        {
            cm.AutoMap();
            cm.MapIdMember(p => p.Id)
                .SetIdGenerator(CombGuidGenerator.Instance)
                .SetSerializer(new GuidSerializer(GuidRepresentation.Standard));
            cm.MapMember(p => p.Codigo).SetIsRequired(true);
            cm.MapMember(p => p.Inicio).SetIsRequired(true);
            cm.MapMember(p => p.Fim).SetIsRequired(true);
            cm.MapMember(p => p.Perguntas);
        });
    }
}