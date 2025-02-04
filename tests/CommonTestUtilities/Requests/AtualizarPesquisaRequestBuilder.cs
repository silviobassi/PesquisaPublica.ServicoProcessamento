using Bogus;
using ServicoProcessamento.Communication.Pesquisa.Requests;

namespace CommonTestUtilities.Requests;

public static class AtualizarPesquisaRequestBuilder
{
    public static AtualizarPesquisaRequest Build(string idPesquisa)
    {
        var request = new Faker<AtualizarPesquisaRequest>()
            .RuleFor(pesquisa => pesquisa.Id, _ => idPesquisa)
            .RuleFor(pesquisa => pesquisa.Codigo, f => f.Random.Word())
            .RuleFor(pesquisa => pesquisa.Inicio, _ => "2022-09-01T00:00:00")
            .RuleFor(pesquisa => pesquisa.Fim, _ => "2022-09-30T23:59:59")
            .Generate();

        return request;
    }
}