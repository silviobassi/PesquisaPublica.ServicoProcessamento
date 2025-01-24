using E7.EasyResult;

namespace ServicoProcessamento.Pesquisa.RemoverPesquisa;

public interface IRemoverPesquisaUseCase
{
    Task<Result> ExecuteAsync(string idPesquisa);
}