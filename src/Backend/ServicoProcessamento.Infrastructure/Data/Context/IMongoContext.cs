﻿using MongoDB.Driver;
using ServicoProcessamento.Domain.Pesquisa.Entities;
using ServicoProcessamento.Domain.Respondedor.Entities;

namespace ServicoProcessamento.Infrastructure.Data.Context;

public interface IMongoContext
{
    IMongoCollection<Pesquisa> Pesquisas { get; }
    IMongoCollection<Pergunta> Perguntas { get; }
    IMongoCollection<Alternativa> Alternativas { get; }
    IMongoCollection<Respondedor> Respondedores { get; }
}