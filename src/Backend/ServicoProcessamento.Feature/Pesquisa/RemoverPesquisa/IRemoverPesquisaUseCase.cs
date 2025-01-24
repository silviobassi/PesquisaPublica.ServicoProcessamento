using E7.EasyResult;

namespace ServicoProcessamento.Feature.Pesquisa.RemoverPesquisa;

public interface IRemoverPesquisaUseCase
{
    Task<Result> ExecuteAsync(string idPesquisa);
}