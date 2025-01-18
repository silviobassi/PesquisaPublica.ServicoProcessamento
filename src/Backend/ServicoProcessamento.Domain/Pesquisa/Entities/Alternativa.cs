namespace ServicoProcessamento.Domain.Pesquisa.Entities;

public sealed class Alternativa
{
    public string Id { get; set; } = string.Empty;
    public string Descricao { get; init; } = string.Empty;
    public List<string> RespondedorIds { get; init; } = [];
}