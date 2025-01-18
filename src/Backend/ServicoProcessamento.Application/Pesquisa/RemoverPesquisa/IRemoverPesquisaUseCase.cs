namespace ServicoProcessamento.Application.Pesquisa.RemoverPesquisa;

public interface IRemoverPesquisaUseCase
{
    Task ExecuteAsync(string idPesquisa);
}