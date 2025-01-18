namespace ServicoProcessamento.Domain.Pesquisa.Entities;

public sealed class Pesquisa
{
    public string Id { get; set; } = string.Empty;
    public string Codigo { get; init; } = string.Empty;

    // alterar para DateTimeOffset
    public DateTime Inicio { get; init; }
    public DateTime Fim { get; init; }
    public bool Ativa { get; private set; } = true;
    public bool Expirada => DateTime.Now > Fim;
    public List<Pergunta>? Perguntas { get; init; } = [];

    public void Desativar() => Ativa = false;

    public void Ativar() => Ativa = true;

    public void AddPergunta(Pergunta pergunta) => Perguntas?.Add(pergunta);

    public bool PodeResponder() => Ativa && !Expirada;

    public bool EstaSendoRespondida => NaoExpirada && TemPerguntaRespondida;

    private bool NaoExpirada => !Expirada;

    private bool TemPerguntaRespondida => Perguntas?.Any(p => p.TemAlternativaRespondida) ?? false;
}