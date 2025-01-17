namespace ServicoProcessamento.Application.Pesquisa.ExcluirPesquisa;

public interface IRemoverPesquisaUseCase
{
    Task ExecuteAsync(string idPesquisa);
}