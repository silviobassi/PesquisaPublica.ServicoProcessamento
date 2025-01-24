namespace ServicoProcessamento.Domain.Pesquisa.Repositories;

public interface IPesquisaRepository
{
    Task CreateAsync(Entities.Pesquisa pesquisa);
    Task<Entities.Pesquisa?> ObterPesquisaPorIdAsync(string idPesquisa);
    Task<Entities.Pesquisa?> AtualizarPesquisaAsync(Entities.Pesquisa pesquisa);
    Task<Entities.Pesquisa?> RemoverPesquisaAsync(string idPesquisa);
}