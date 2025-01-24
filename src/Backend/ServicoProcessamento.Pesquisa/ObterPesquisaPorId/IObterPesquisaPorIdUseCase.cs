using ServicoProcessamento.Communication.Responses;

namespace ServicoProcessamento.Pesquisa.ObterPesquisaPorId;

public interface IObterPesquisaPorIdUseCase
{
    Task<ObterPesquisaResponse> ExecuteAsync(string idPesquisa);
}