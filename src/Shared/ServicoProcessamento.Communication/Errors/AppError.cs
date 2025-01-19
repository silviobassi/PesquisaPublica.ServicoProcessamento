using System.Net;

namespace ServicoProcessamento.Communication.Errors;

public abstract class AppError(string detail, ErrorType errorType, string errorCodeName)
{
    public string Detail { get; } = detail;
    public ErrorType ErrorType { get; } = errorType;
    public string ErrorCodeName { get; } = errorCodeName;

    public abstract List<string> GetErrorsMessage();

    public abstract HttpStatusCode GetHttpStatusCode();
}