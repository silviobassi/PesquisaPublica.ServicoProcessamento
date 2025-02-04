namespace ServicoProcessamento.Domain.Pesquisa.Entities;

public sealed class PerguntaEntity(string id, string descricao)
{
    public string Id { get; private set; } = id;
    public string Descricao { get; private set; } = descricao;
    public List<AlternativaEntity>? Alternativas { get; init; } = [];

    public void ObterId(string id) => Id = id;

    public void AddAlternativa(AlternativaEntity alternativaEntity) => Alternativas?.Add(alternativaEntity);

    public bool TemAlternativaRespondida => Alternativas?.Any(a => a.RespondedorIds.Count > 0) ?? false;
}