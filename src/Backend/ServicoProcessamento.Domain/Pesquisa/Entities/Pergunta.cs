namespace ServicoProcessamento.Domain.Pesquisa.Entities;

public sealed class Pergunta
{
    public string Id { get; set; } = string.Empty;
    public string Descricao { get; init; } = string.Empty;
    public List<Alternativa>? Alternativas { get; init; } = [];
}