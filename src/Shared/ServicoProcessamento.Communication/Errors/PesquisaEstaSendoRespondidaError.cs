using System.Net;
using E7.EasyResult.Errors;

namespace ServicoProcessamento.Communication.Errors;

public class PesquisaEstaSendoRespondidaError() : AppError("A Pesquisa está sendo respondida, não pode ser removida",
    ErrorType.ConflictRule, nameof(PesquisaEstaSendoRespondidaError))
{
    public override List<string?> GetErrorsMessage() => [Detail];

    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.Conflict;
}