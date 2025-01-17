using ServicoProcessamento.Communication.Requests;
using ServicoProcessamento.Communication.Responses;

namespace ServicoProcessamento.Application.Pesquisa.CreatePesquisa;

public interface ICreatePesquisaUseCase
{
    Task<CreatePesquisaResponse> ExecuteAsync(CreatePesquisaRequest request);
}