using MongoDB.Driver;
using ServicoProcessamento.Domain.Pesquisa.Entities;
using ServicoProcessamento.Domain.Respondedor.Entities;

namespace ServicoProcessamento.Infrastructure.Data.Context;

public interface IMongoContext
{
    IMongoCollection<PesquisaEntity> Pesquisas { get; }
    IMongoCollection<PerguntaEntity> Perguntas { get; }
    IMongoCollection<AlternativaEntity> Alternativas { get; }
    IMongoCollection<RespondedorEntity> Respondedores { get; }
}