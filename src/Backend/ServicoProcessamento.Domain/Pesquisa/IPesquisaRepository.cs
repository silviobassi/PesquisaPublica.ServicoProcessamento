namespace ServicoProcessamento.Domain.Pesquisa;

public interface IPesquisaRepository
{
    Task CreateAsync(Pesquisa pesquisa);
    Task<Pesquisa?> ObterPesquisaPorIdAsync(string idPesquisa);
    Task<Pesquisa?> AtualizarPesquisaAsync(Pesquisa pesquisa);
    Task<Pesquisa?> RemoverPesquisaAsync(string idPesquisa);
}