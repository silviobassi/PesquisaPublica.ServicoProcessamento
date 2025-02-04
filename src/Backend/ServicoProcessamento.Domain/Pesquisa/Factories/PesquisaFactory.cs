using ServicoProcessamento.Domain.Pesquisa.Entities;

namespace ServicoProcessamento.Domain.Pesquisa.Factories;

public static class PesquisaFactory
{
    public static PesquisaEntity Criar(string? codigo, DateTimeOffset? inicio, DateTimeOffset? fim)
        => new(codigo, inicio, fim);

    public static PesquisaEntity Atualizar(string? id, string? codigo, DateTimeOffset? inicio, DateTimeOffset? fim)
    {
        var pesquisaEntity = new PesquisaEntity(codigo, inicio, fim);
        pesquisaEntity.ObterId(id);
        return pesquisaEntity;
    }
}