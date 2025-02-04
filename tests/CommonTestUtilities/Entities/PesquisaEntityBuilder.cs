using Bogus;
using ServicoProcessamento.Domain.Pesquisa.Entities;

namespace CommonTestUtilities.Entities;

public class PesquisaEntityBuilder
{
    public static PesquisaEntity Build(DateTimeOffset? inicio = null, DateTimeOffset? fim = null)
    {
        var pesquisa = new Faker<PesquisaEntity>()
            .RuleFor(pesquisa => pesquisa.Id, f => f.Random.Word())
            .RuleFor(pesquisa => pesquisa.Codigo, f => f.Random.Word())
            .RuleFor(pesquisa => pesquisa.Inicio, _ => inicio)
            .RuleFor(pesquisa => pesquisa.Fim, _ => fim)
            .Generate();

        return pesquisa;
    }
}