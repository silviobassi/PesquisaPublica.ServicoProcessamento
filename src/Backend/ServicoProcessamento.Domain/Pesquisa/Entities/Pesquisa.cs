namespace ServicoProcessamento.Domain.Pesquisa.Entities;

public sealed class Pesquisa(string codigo, DateTime inicio, DateTime fim)
{
    public string Id { get; private set; } = string.Empty;
    public string Codigo { get; private set; } = codigo;

    // alterar para DateTimeOffset
    public DateTime Inicio { get; private set; } = inicio;
    public DateTime Fim { get; private set; } = fim;
    public bool Ativa { get; private set; }
    
    public void ObterId(string id) => Id = id;

    private bool Expirada => DateTime.Now > Fim;
    public List<Pergunta>? Perguntas { get; init; } = [];

    public void Desativar() => Ativa = false;

    public void Ativar() => Ativa = true;

    public void AddPergunta(Pergunta pergunta) => Perguntas?.Add(pergunta);

    public bool PodeResponder() => Ativa && !Expirada;

    public bool EstaSendoRespondida => NaoExpirada && TemPerguntaRespondida;

    private bool NaoExpirada => !Expirada;

    private bool TemPerguntaRespondida => Perguntas?.Any(p => p.TemAlternativaRespondida) ?? false;
}