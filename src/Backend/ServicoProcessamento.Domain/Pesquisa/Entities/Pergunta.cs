namespace ServicoProcessamento.Domain.Pesquisa.Entities;

public sealed class Pergunta
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Descricao { get; init; } = string.Empty;
    public List<Alternativa>? Alternativas { get; init; } = [];
}