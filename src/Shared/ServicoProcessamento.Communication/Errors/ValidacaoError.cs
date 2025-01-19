using System.Net;

namespace ServicoProcessamento.Communication.Errors;

public class ValidacaoError(List<string?> errorsMessage)
    : AppError("Erro de validação", ErrorType.ValidationRule, nameof(ValidacaoError))
{
    public override List<string?> GetErrorsMessage() => errorsMessage;
    
    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;
}