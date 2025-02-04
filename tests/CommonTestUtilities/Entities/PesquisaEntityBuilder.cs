using Bogus;
using MongoDB.Bson;
using ServicoProcessamento.Domain.Pesquisa.Entities;

namespace CommonTestUtilities.Entities;

public static class PesquisaEntityBuilder
{
    public static PesquisaEntity Build(DateTimeOffset? inicio = null, DateTimeOffset? fim = null)
    {
        return new Faker<PesquisaEntity>()
            .RuleFor(pesquisa => pesquisa.Id, _ => ObjectId.GenerateNewId().ToString())
            .RuleFor(pesquisa => pesquisa.Codigo, f => f.Random.Word())
            .RuleFor(pesquisa => pesquisa.Inicio, _ => inicio)
            .RuleFor(pesquisa => pesquisa.Fim, _ => fim)
            .Generate();
    }
}