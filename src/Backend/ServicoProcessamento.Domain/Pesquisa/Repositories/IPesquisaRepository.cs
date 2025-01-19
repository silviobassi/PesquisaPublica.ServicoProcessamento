namespace ServicoProcessamento.Domain.Pesquisa.Repositories;

public interface IPesquisaRepository
{
    Task CreateAsync(Entities.Pesquisa pesquisa);
    Task<Entities.Pesquisa> ObterPesquisaPorIdAsync(string idPesquisa);
    Task<(long MatchedCount, long ModifiedCount)> AtualizarPesquisaAsync(Entities.Pesquisa pesquisa);
    Task<long> RemoverPesquisaAsync(string idPesquisa);
}