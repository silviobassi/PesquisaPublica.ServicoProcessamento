using ServicoProcessamento.Communication.Responses;

namespace ServicoProcessamento.Application.Pesquisa.ObterPesquisaPorId;

public interface IObterPesquisaPorIdUseCase
{
    Task<ObterPesquisaResponse> ExecuteAsync(string idPesquisa);
}