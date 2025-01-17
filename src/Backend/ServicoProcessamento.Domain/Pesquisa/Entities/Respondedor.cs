namespace ServicoProcessamento.Domain.Pesquisa.Entities;

public class Respondedor
{
    public string Id { get; init; } = string.Empty;
    public string Nome { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public int Idade { get; init; }
}