using E7.EasyResult;
using ServicoProcessamento.Communication.Requests;
using ServicoProcessamento.Communication.Responses;

namespace ServicoProcessamento.Pesquisa.CreatePesquisa;

public interface ICreatePesquisaUseCase
{
    Task<Result<CreatePesquisaResponse>> ExecuteAsync(CreatePesquisaRequest request);
}