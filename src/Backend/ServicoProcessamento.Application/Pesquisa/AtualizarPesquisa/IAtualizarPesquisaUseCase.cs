using E7.EasyResult;
using ServicoProcessamento.Communication.Requests;

namespace ServicoProcessamento.Application.Pesquisa.AtualizarPesquisa;

public interface IAtualizarPesquisaUseCase
{
    Task<Result> ExecuteAsync(AtualizarPesquisaRequest request);
}