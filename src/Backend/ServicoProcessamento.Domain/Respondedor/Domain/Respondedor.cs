namespace ServicoProcessamento.Domain.Respondedor.Domain;

public sealed class Respondedor(string id, string nome, string email, int idade)
{
    public string Id { get; private set; } = id;
    public string Nome { get; private set; } = nome;
    public string Email { get; private set; } = email;
    public int Idade { get; private set; } = idade;

    public void ObterId(string id) => Id = id;
}