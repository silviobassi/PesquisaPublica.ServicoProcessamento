using MongoDB.Bson;
using MongoDB.Driver;
using ServicoProcessamento.Domain.Pesquisa.Entities;
using ServicoProcessamento.Domain.Pesquisa.Repositories;
using ServicoProcessamento.Infrastructure.Data.Context;

namespace ServicoProcessamento.Infrastructure.Data.Repositories;

public class PesquisaRepository(IMongoContext context) : IPesquisaRepository
{
    public async Task CreateAsync(Pesquisa pesquisa)
    {
        pesquisa.Id = ObjectId.GenerateNewId().ToString();
        await context.Pesquisas.InsertOneAsync(pesquisa);
    }

    public async Task<Pesquisa> ObterPesquisaPorIdAsync(string idPesquisa)
    {
        var filter = Builders<Pesquisa>.Filter.Eq(p => p.Id, idPesquisa);
        return await context.Pesquisas.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<(long MatchedCount, long ModifiedCount)> AtualizarPesquisaAsync(Pesquisa pesquisa)
    {
        var filter = Builders<Pesquisa>.Filter.Eq(p => p.Id, pesquisa.Id);

        var update = Builders<Pesquisa>.Update
            .Set(p => p.Codigo, pesquisa.Codigo)
            .Set(p => p.Inicio, pesquisa.Inicio)
            .Set(p => p.Fim, pesquisa.Fim);
        
        var updateResult = await context.Pesquisas.UpdateOneAsync(filter, update);
        
        return (updateResult.MatchedCount, updateResult.ModifiedCount);
    }

    public async Task<long> RemoverPesquisaAsync(string idPesquisa)
    {
        var filter = Builders<Pesquisa>.Filter.Eq(p => p.Id, idPesquisa);
        // verificar se foi excluído realmente
        var deleteResult = await context.Pesquisas.DeleteOneAsync(filter);
        return deleteResult.DeletedCount;
    }
}