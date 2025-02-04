using System.Net;

namespace ServicoProcessamento.Communication.E7.EasyResult.Errors;

/// <summary>
/// Represents an error that occurs when fields are invalid.
/// </summary>
/// <param name="errorsMessages">The list of error messages.</param>
/// <author>Silvio Luiz Bassi</author>
/// <company>Enfatiza7 Consultoria em Tecnologia LTDA</company>
public sealed class InvalidFieldsError(List<string?> errorsMessages)
    : AppError("Invalid Fields.", ErrorType.ValidationRule, nameof(InvalidFieldsError))
{
    /// <summary>
    /// Gets the list of error messages.
    /// </summary>
    /// <returns>A list of error messages.</returns>
    public override List<string?> GetErrorsMessage() => errorsMessages;

    /// <summary>
    /// Gets the HTTP status code associated with the error.
    /// </summary>
    /// <returns>The HTTP status code for invalid fields (400) <see cref="Result{T}"/>.</returns>
    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;
}