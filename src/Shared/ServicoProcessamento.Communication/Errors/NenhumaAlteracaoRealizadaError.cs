using System.Net;
using E7.EasyResult.Errors;

namespace ServicoProcessamento.Communication.Errors;

public class NenhumaAlteracaoRealizadaError() : AppError("Nenhuma alteração realizada", ErrorType.ConflictRule,
    nameof(NenhumaAlteracaoRealizadaError))
{
    public override List<string?> GetErrorsMessage() => [Detail];
    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.Conflict;
}