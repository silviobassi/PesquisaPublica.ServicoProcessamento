namespace ServicoProcessamento.Communication.E7.EasyResult.Errors;

/// <summary>
/// Defines the types of errors that can occur in the application when the result pattern is applied.
/// </summary>
/// <author>Silvio Luiz Bassi</author>
/// <company>Enfatiza7 Consultoria em Tecnologia LTDA</company>
public enum ErrorType
{
    /// <summary>
    /// Error related to bad request.
    /// </summary>
    BadRequestRule = 100,

    /// <summary>
    /// Error related to business rules.
    /// </summary>
    BusinessRule = 200,

    /// <summary>
    /// Error related to operation failure on database.
    /// </summary>
    ConflictRule = 300,

    /// <summary>
    /// Error related to forbidden access.
    /// </summary>
    ForbiddenAccessRule = 400,

    /// <summary>
    /// Error related to resources not found.
    /// </summary>
    NotFoundRule = 500,

    /// <summary>
    /// Error related to data validation.
    /// </summary>
    ValidationRule = 600,

    /// <summary>
    /// Error related to unauthorized access.
    /// </summary>
    UnauthorizedAccess = 700,

    FailToCreateObject = 800,
}