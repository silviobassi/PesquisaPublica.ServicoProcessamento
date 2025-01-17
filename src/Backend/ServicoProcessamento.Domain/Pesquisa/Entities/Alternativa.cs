namespace ServicoProcessamento.Domain.Pesquisa.Entities;

public sealed class Alternativa
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Descricao { get; init; } = string.Empty;
    public List<Guid> RespondedorIds { get; init; } = [];
}