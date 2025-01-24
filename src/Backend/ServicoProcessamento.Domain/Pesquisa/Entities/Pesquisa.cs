namespace ServicoProcessamento.Domain.Pesquisa.Entities;

/// <summary>
/// Representa uma entidade de pesquisa com suas propriedades e métodos.
/// </summary>
/// <param name="codigo">O código da pesquisa.</param>
/// <param name="inicio">A data e hora de início da pesquisa.</param>
/// <param name="fim">A data e hora de término da pesquisa.</param>
public sealed class Pesquisa(string codigo, DateTimeOffset? inicio, DateTimeOffset? fim)
{
    /// <summary>
    /// Obtém o ID da pesquisa.
    /// </summary>
    public string Id { get; private set; } = string.Empty;

    /// <summary>
    /// Obtém o código da pesquisa.
    /// </summary>
    public string Codigo { get; private set; } = codigo;

    /// <summary>
    /// Obtém a data e hora de início da pesquisa.
    /// </summary>
    public DateTimeOffset? Inicio { get; private set; } = inicio;

    /// <summary>
    /// Obtém a data e hora de término da pesquisa.
    /// </summary>
    public DateTimeOffset? Fim { get; private set; } = fim;

    /// <summary>
    /// Obtém um valor indicando se a pesquisa está ativa.
    /// </summary>
    public bool Ativa { get; private set; }

    /// <summary>
    /// Recebe o ID da pesquisa gerado por pacote externo <see cref="MongoDB.Driver"/> (ObjectId.GenerateNewId().ToString()).
    /// </summary>
    /// <param name="id">O ID a ser definido.</param>
    public void ObterId(string id) => Id = id;

    /// <summary>
    /// Obtém um valor indicando se a pesquisa expirou.
    /// </summary>
    private bool Expirada => DateTime.Now > Fim;

    /// <summary>
    /// Obtém ou define a lista de perguntas da pesquisa.
    /// </summary>
    public List<Pergunta>? Perguntas { get; init; } = [];

    /// <summary>
    /// Desativa a pesquisa.
    /// </summary>
    public void Desativar() => Ativa = false;

    /// <summary>
    /// Ativa a pesquisa.
    /// </summary>
    public void Ativar() => Ativa = true;

    /// <summary>
    /// Adiciona uma pergunta à pesquisa.
    /// </summary>
    /// <param name="pergunta">A pergunta a ser adicionada.</param>
    public void AddPergunta(Pergunta pergunta) => Perguntas?.Add(pergunta);

    /// <summary>
    /// Verifica se a pesquisa pode ser respondida.
    /// </summary>
    /// <returns>Verdadeiro se a pesquisa estiver ativa e não expirada; caso contrário, falso.</returns>
    public bool PodeResponder() => Ativa && !Expirada;

    /// <summary>
    /// Verifica se a pesquisa está sendo respondida.
    /// </summary>
    public bool EstaSendoRespondida => NaoExpirada && TemPerguntaRespondida;

    /// <summary>
    /// Verifica se a pesquisa não expirou.
    /// </summary>
    private bool NaoExpirada => !Expirada;

    /// <summary>
    /// Verifica se alguma pergunta na pesquisa foi respondida.
    /// </summary>
    private bool TemPerguntaRespondida => Perguntas?.Exists(p => p.TemAlternativaRespondida) ?? false;
}