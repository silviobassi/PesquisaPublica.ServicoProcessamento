namespace ServicoProcessamento.Domain.Pesquisa.Repositories;

using Entities;

public interface IPesquisaRepository
{
    Task CreateAsync(Pesquisa pesquisa);
    Task<Pesquisa> ObterPesquisaPorIdAsync(string idPesquisa);
    Task AtualizarPesquisaAsync(Pesquisa pesquisa);
}