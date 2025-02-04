using ServicoProcessamento.Communication.E7.EasyResult;
using ServicoProcessamento.Communication.Pesquisa.Requests;
using ServicoProcessamento.Communication.Pesquisa.Responses;

namespace ServicoProcessamento.Feature.Pesquisa.CreatePesquisa;

public interface ICreatePesquisaUseCase
{
    Task<Result<CreatePesquisaResponse>> ExecuteAsync(CreatePesquisaRequest request);
}