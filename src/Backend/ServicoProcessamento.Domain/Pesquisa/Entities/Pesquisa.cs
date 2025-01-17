namespace ServicoProcessamento.Domain.Pesquisa.Entities;

public sealed class Pesquisa
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Codigo { get; init; } = string.Empty;
    public DateTime Inicio { get; init; }
    public DateTime Fim { get; init; }
    public List<Pergunta>? Perguntas { get; init; } = [];

    public void AddPergunta(Pergunta pergunta)
    {
        Perguntas?.Add(pergunta);
    }
}