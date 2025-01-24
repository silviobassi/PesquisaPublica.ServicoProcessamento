namespace ServicoProcessamento.Domain.Pesquisa;

public sealed class Pergunta(string id, string descricao)
{
    public string Id { get; private set; } = id;
    public string Descricao { get; private set; } = descricao;
    public List<Alternativa>? Alternativas { get; init; } = [];

    public void ObterId(string id) => Id = id;

    public void AddAlternativa(Alternativa alternativa) => Alternativas?.Add(alternativa);

    public bool TemAlternativaRespondida => Alternativas?.Any(a => a.RespondedorIds.Count > 0) ?? false;
}