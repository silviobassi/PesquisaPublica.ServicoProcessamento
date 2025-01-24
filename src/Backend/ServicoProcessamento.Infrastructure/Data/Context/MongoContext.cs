using MongoDB.Driver;
using ServicoProcessamento.Domain.Pesquisa;
using ServicoProcessamento.Domain.Respondedor.Domain;

namespace ServicoProcessamento.Infrastructure.Data.Context;

public class MongoContext(IMongoClient client) : IMongoContext
{
    private IMongoDatabase Db => client.GetDatabase("PesquisaPublicaDb");

    public IMongoCollection<Pesquisa> Pesquisas => Db.GetCollection<Pesquisa>("Pesquisas");

    public IMongoCollection<Pergunta> Perguntas => Db.GetCollection<Pergunta>("Perguntas");

    public IMongoCollection<Alternativa> Alternativas => Db.GetCollection<Alternativa>("Alternativas");

    public IMongoCollection<Respondedor> Respondedores => Db.GetCollection<Respondedor>("Respondedores");
}