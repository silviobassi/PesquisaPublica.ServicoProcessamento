using MongoDB.Bson;
using MongoDB.Driver;
using ServicoProcessamento.Domain.Pesquisa.Entities;
using ServicoProcessamento.Domain.Pesquisa.Repositories;
using ServicoProcessamento.Infrastructure.Data.Context;

namespace ServicoProcessamento.Infrastructure.Data.Repositories;

public class PesquisaRepository(IMongoContext context) : IPesquisaRepository
{
    public async Task CreateAsync(PesquisaEntity pesquisa)
    {
        var idPesquisa = ObjectId.GenerateNewId().ToString();
        pesquisa.ObterId(idPesquisa);
        await context.Pesquisas.InsertOneAsync(pesquisa);
    }

    public async Task<PesquisaEntity?> ObterPesquisaPorIdAsync(string idPesquisa)
    {
        var filter = Builders<PesquisaEntity>.Filter.Eq(p => p.Id, idPesquisa);
        return await context.Pesquisas.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<long> AtualizarPesquisaAsync(PesquisaEntity? pesquisa)
    {
        var filter = Builders<PesquisaEntity>.Filter.Eq(p => p.Id, pesquisa?.Id);

        var update = Builders<PesquisaEntity>.Update
            .Set(p => p.Codigo, pesquisa?.Codigo)
            .Set(p => p.Inicio, pesquisa?.Inicio)
            .Set(p => p.Fim, pesquisa?.Fim);

        var result = await context.Pesquisas.UpdateOneAsync(filter, update);

        return result.ModifiedCount;
    }

    public async Task<PesquisaEntity?> RemoverPesquisaAsync(string idPesquisa)
    {
        var filter = Builders<PesquisaEntity>.Filter.Eq(p => p.Id, idPesquisa);

        var pesquisaDeleted = await context.Pesquisas.FindOneAndDeleteAsync(filter);

        return pesquisaDeleted;
    }
}