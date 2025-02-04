using System.Net;
using ServicoProcessamento.Communication.E7.EasyResult.Errors;

namespace ServicoProcessamento.Communication.Pesquisa.Errors;

public class PesquisaNaoRemovidaOuInexistenteError() : AppError("A Pesquisa não foi removida, provavelmente não exista",
    ErrorType.ConflictRule, nameof(PesquisaNaoRemovidaOuInexistenteError))
{
    public override List<string?> GetErrorsMessage() => [Message];

    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.Conflict;
}