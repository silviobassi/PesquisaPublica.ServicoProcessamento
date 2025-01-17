namespace ServicoProcessamento.Domain.Pesquisa.Entities;

public sealed class Pesquisa
{
    public string Id { get; set; } = string.Empty;
    public string Codigo { get; init; } = string.Empty;
    
    // alterar para DateTimeOffset
    public DateTime Inicio { get; init; }
    public DateTime Fim { get; init; }
    public List<Pergunta>? Perguntas { get; init; } = [];

    public void AddPergunta(Pergunta pergunta)
    {
        Perguntas?.Add(pergunta);
    }
}