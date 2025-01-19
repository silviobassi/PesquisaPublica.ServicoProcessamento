using System.Net;

namespace ServicoProcessamento.Communication.Errors;

public class NenhumaAlteracaoRealizadaError() : AppError("Nenhuma alteração realizada", ErrorType.BusinessRule,
    nameof(NenhumaAlteracaoRealizadaError))
{
    public override List<string> GetErrorsMessage() => [Detail];
    
    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.Conflict;
}