using System.Net;
using E7.EasyResult.Errors;

namespace ServicoProcessamento.Communication.Errors;

public class ValidacaoError(List<string?> errorsMessages)
    : AppError("Erro de validação", ErrorType.ValidationRule, nameof(ValidacaoError))
{
    public override List<string?> GetErrorsMessage() => errorsMessages;

    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;
}