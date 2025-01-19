using System.Net;

namespace ServicoProcessamento.Communication.Errors;

public class ValidacaoError(List<string> errorsMessage)
    : AppError("Erro de validação", ErrorType.Validation, nameof(ValidacaoError))
{
    public override List<string> GetErrorsMessage() => errorsMessage;
    
    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;
}