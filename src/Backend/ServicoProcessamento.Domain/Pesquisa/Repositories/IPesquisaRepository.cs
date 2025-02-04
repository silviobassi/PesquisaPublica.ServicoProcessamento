using ServicoProcessamento.Domain.Pesquisa.Entities;

namespace ServicoProcessamento.Domain.Pesquisa.Repositories;

public interface IPesquisaRepository
{
    Task CreateAsync(PesquisaEntity pesquisa);
    Task<PesquisaEntity?> ObterPesquisaPorIdAsync(string idPesquisa);
    Task<long> AtualizarPesquisaAsync(PesquisaEntity? pesquisa);
    Task<PesquisaEntity?> RemoverPesquisaAsync(string idPesquisa);
}