using MongoDB.Bson;
using MongoDB.Driver;
using ServicoProcessamento.Domain.Pesquisa;
using ServicoProcessamento.Infrastructure.Data.Context;

namespace ServicoProcessamento.Infrastructure.Data.Repositories;

public class PesquisaRepository(IMongoContext context) : IPesquisaRepository
{
    public async Task CreateAsync(Pesquisa pesquisa)
    {
        var idPesquisa = ObjectId.GenerateNewId().ToString();
        pesquisa.ObterId(idPesquisa);
        await context.Pesquisas.InsertOneAsync(pesquisa);
    }

    public async Task<Pesquisa?> ObterPesquisaPorIdAsync(string idPesquisa)
    {
        var filter = Builders<Pesquisa>.Filter.Eq(p => p.Id, idPesquisa);
        return await context.Pesquisas.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<Pesquisa?> AtualizarPesquisaAsync(Pesquisa pesquisa)
    {
        var filter = Builders<Pesquisa>.Filter.Eq(p => p.Id, pesquisa.Id);

        var update = Builders<Pesquisa>.Update
            .Set(p => p.Codigo, pesquisa.Codigo)
            .Set(p => p.Inicio, pesquisa.Inicio)
            .Set(p => p.Fim, pesquisa.Fim);

        return await context.Pesquisas.FindOneAndUpdateAsync(filter, update);
    }

    public async Task<Pesquisa?> RemoverPesquisaAsync(string idPesquisa)
    {
        var filter = Builders<Pesquisa>.Filter.Eq(p => p.Id, idPesquisa);

        var pesquisaDeleted = await context.Pesquisas.FindOneAndDeleteAsync(filter);

        return pesquisaDeleted;
    }
}