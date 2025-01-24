using E7.EasyResult;

namespace ServicoProcessamento.Application.Pesquisa.RemoverPesquisa;

public interface IRemoverPesquisaUseCase
{
    Task<Result> ExecuteAsync(string idPesquisa);
}