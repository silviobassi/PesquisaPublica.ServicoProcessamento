using System.Globalization;

namespace ServicoProcessamento.Communication.Pesquisa.Requests;

public record CreatePesquisaRequest(string Codigo, string Inicio, string Fim)
{
    public DateTimeOffset? InicioAsDateTimeOffset =>
        DateTimeOffset.TryParse(Inicio, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result)
            ? result
            : null;

    public DateTimeOffset? FimAsDateTimeOffset =>
        DateTimeOffset.TryParse(Fim, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result)
            ? result
            : null;
}