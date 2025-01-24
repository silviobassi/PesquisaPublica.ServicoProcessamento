using System.Net;
using E7.EasyResult.Errors;

namespace ServicoProcessamento.Communication.Errors;

public class PesquisaNaoRemovidaOuInexistenteError() : AppError("A Pesquisa não foi removida, provavelmente não exista",
    ErrorType.ConflictRule, nameof(PesquisaNaoRemovidaOuInexistenteError))
{
    public override List<string?> GetErrorsMessage() => [Detail];

    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.Conflict;
}