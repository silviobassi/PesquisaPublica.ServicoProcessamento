using System.Globalization;

namespace ServicoProcessamento.Communication.Pesquisa.Requests;

public record AtualizarPesquisaRequest
{
    public string Id { get; init; } = string.Empty;
    public string Codigo { get; init; } = string.Empty;
    public string? Inicio { get; init; } = string.Empty;
    public string? Fim { get; init; } = string.Empty;

    public DateTimeOffset? InicioAsDateTimeOffset =>
        DateTimeOffset.TryParse(Inicio, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result)
            ? result
            : null;

    public DateTimeOffset? FimAsDateTimeOffset =>
        DateTimeOffset.TryParse(Fim, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result) ? result : null;
}