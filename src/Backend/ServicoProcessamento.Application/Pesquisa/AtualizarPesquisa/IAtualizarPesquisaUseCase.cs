using ServicoProcessamento.Communication.Requests;

namespace ServicoProcessamento.Application.Pesquisa.AtualizarPesquisa;

public interface IAtualizarPesquisaUseCase
{
    Task ExecuteAsync(AtualizarPesquisaRequest request);
}