using Bogus;
using ServicoProcessamento.Domain.Pesquisa.Entities;

namespace CommonTestUtilities.Entities;

public abstract class PesquisaEntityBuilder
{
    public static PesquisaEntity Build(DateTimeOffset? inicio = null, DateTimeOffset? fim = null)
    {
        var pesquisa = new Faker<PesquisaEntity>()
            .RuleFor(pesquisa => pesquisa.Id, _ => Guid.NewGuid().ToString())
            .RuleFor(pesquisa => pesquisa.Codigo, f => f.Random.Word())
            .RuleFor(pesquisa => pesquisa.Inicio, _ => inicio)
            .RuleFor(pesquisa => pesquisa.Fim, _ => fim)
            .Generate();

        return pesquisa;
    }
}