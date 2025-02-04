using MongoDB.Driver;
using ServicoProcessamento.Domain.Pesquisa;
using ServicoProcessamento.Domain.Pesquisa.Entities;
using ServicoProcessamento.Domain.Respondedor;
using ServicoProcessamento.Domain.Respondedor.Entities;

namespace ServicoProcessamento.Infrastructure.Data.Context;

public class MongoContext(IMongoClient client) : IMongoContext
{
    private IMongoDatabase Db => client.GetDatabase("PesquisaPublicaDb");

    public IMongoCollection<PesquisaEntity> Pesquisas => Db.GetCollection<PesquisaEntity>("Pesquisas");

    public IMongoCollection<PerguntaEntity> Perguntas => Db.GetCollection<PerguntaEntity>("Perguntas");

    public IMongoCollection<AlternativaEntity> Alternativas => Db.GetCollection<AlternativaEntity>("Alternativas");

    public IMongoCollection<RespondedorEntity> Respondedores => Db.GetCollection<RespondedorEntity>("Respondedores");
}