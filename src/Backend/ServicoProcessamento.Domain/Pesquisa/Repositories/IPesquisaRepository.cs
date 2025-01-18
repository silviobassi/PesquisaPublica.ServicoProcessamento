namespace ServicoProcessamento.Domain.Pesquisa.Repositories;

using Entities;

public interface IPesquisaRepository
{
    Task CreateAsync(Pesquisa pesquisa);
    Task<Pesquisa> ObterPesquisaPorIdAsync(string idPesquisa);
    Task<(long MatchedCount, long ModifiedCount)> AtualizarPesquisaAsync(Pesquisa pesquisa);
    Task<long> RemoverPesquisaAsync(string idPesquisa);
}