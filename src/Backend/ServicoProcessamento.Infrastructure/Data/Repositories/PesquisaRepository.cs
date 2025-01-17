using MongoDB.Driver;
using ServicoProcessamento.Domain.Pesquisa.Entities;
using ServicoProcessamento.Domain.Pesquisa.Repositories;
using ServicoProcessamento.Infrastructure.Data.Context;

namespace ServicoProcessamento.Infrastructure.Data.Repositories;

public class PesquisaRepository(IMongoContext context) : IPesquisaRepository
{
    public async Task Create(Pesquisa pesquisa)
    {
        await context.Pesquisas.InsertOneAsync(pesquisa);
    }

    // mudar este método para alterar somente perguntas
    public async Task<object> InserirPerguntaAsync(Pesquisa pesquisa)
    {
        var filter = Builders<Pesquisa>.Filter.Eq("Codigo", pesquisa.Codigo);

        var update = Builders<Pesquisa>.Update.Set(p => p.Perguntas, pesquisa.Perguntas);

        return await context.Pesquisas.UpdateOneAsync(filter, update);
    }

    public async Task<IEnumerable<Pesquisa>> GetAllAsync()
    {
        return await context.Pesquisas
            .Find(_ => true)
            .Project(p => new Pesquisa
            {
                Id = p.Id,
                Codigo = p.Codigo,
                Inicio = p.Inicio,
                Fim = p.Fim
            })
            .ToListAsync();
    }

    public async Task<Pesquisa?> GetPesquisaByCodigoAsync(string codigo)
    {
        var filter = Builders<Pesquisa>.Filter.Eq(p => p.Codigo, codigo);
        return await context.Pesquisas.Find(filter).FirstOrDefaultAsync();
    }

}