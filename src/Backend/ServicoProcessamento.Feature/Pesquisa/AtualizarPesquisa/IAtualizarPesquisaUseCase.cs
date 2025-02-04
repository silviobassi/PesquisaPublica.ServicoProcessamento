using ServicoProcessamento.Communication.E7.EasyResult;
using ServicoProcessamento.Communication.Pesquisa.Requests;

namespace ServicoProcessamento.Feature.Pesquisa.AtualizarPesquisa;

public interface IAtualizarPesquisaUseCase
{
    Task<Result<bool>> ExecuteAsync(AtualizarPesquisaRequest request);
}