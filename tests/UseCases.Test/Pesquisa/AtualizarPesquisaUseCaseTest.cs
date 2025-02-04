using CommonTestUtilities.Entities;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using FluentAssertions;
using ServicoProcessamento.Feature.Pesquisa.AtualizarPesquisa;

namespace UseCases.Test.Pesquisa;

public class AtualizarPesquisaUseCaseTest
{
    [Fact]
    public async Task ExecuteAsync_QuandoPesquisaValida_DeveRetornarSucesso()
    {
        var dataFim = DateTimeOffset.Now;
        var dataInicio = dataFim.AddDays(-1);

        var pesquisa = PesquisaEntityBuilder.Build(dataInicio, dataFim);
        var request = AtualizarPesquisaRequestBuilder.Build(pesquisa.Id!);

        var repository = new PesquisaRepositoryBuilder()
            .ObterPesquisaPorIdAsync(pesquisa, request) // Mock do ObterPesquisaPorIdAsync
            .AtualizarPesquisaAsync() // Mock do AtualizarPesquisaAsync
            .Build();

        var useCase = new AtualizarPesquisaUseCase(repository);

        var result = await useCase.ExecuteAsync(request);

        result.IsSuccess.Should().BeTrue();
    }
}