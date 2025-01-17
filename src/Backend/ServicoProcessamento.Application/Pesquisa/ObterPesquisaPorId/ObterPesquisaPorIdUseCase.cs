using ServicoProcessamento.Communication.Responses;
using ServicoProcessamento.Domain.Pesquisa.Repositories;

namespace ServicoProcessamento.Application.Pesquisa.ObterPesquisaPorId;

public class ObterPesquisaPorIdUseCase(IPesquisaRepository pesquisaRepository) : IObterPesquisaPorIdUseCase
{
    public async Task<ObterPesquisaResponse> ExecuteAsync(string idPesquisa)
    {
        var pesquisaResponse = await pesquisaRepository.ObterPesquisaPorIdAsync(idPesquisa);

        if (pesquisaResponse is null) throw new ArgumentException("Pesquisa não encontrada");

        return new ObterPesquisaResponse(pesquisaResponse.Id, pesquisaResponse.Codigo, pesquisaResponse.Inicio,
            pesquisaResponse.Fim);
    }
}