namespace ServicoProcessamento.Domain.Pesquisa.Repositories;

using Entities;

public interface IPesquisaRepository
{
    Task CreateAsync(Pesquisa pesquisa);
    Task<object> InserirPerguntaAsync(Pesquisa pesquisa);
    Task<IEnumerable<Pesquisa>> GetAllAsync();
    Task<Entities.Pesquisa?> GetPesquisaByCodigoAsync(string codigo);
}