using System.Net;
using ServicoProcessamento.Communication.E7.EasyResult.Errors;

namespace ServicoProcessamento.Communication.Pesquisa.Errors;

public class NenhumaAlteracaoRealizadaError() : AppError("Nenhuma alteração realizada", ErrorType.ConflictRule,
    nameof(NenhumaAlteracaoRealizadaError))
{
    public override List<string?> GetErrorsMessage() => [Message];
    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.Conflict;
}