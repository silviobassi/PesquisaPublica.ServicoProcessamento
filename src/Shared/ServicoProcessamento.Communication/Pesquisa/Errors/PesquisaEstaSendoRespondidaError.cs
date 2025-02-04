using System.Net;
using ServicoProcessamento.Communication.E7.EasyResult.Errors;

namespace ServicoProcessamento.Communication.Pesquisa.Errors;

public class PesquisaEstaSendoRespondidaError() : AppError("A Pesquisa está sendo respondida, não pode ser removida",
    ErrorType.ConflictRule, nameof(PesquisaEstaSendoRespondidaError))
{
    public override List<string?> GetErrorsMessage() => [Message];

    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.Conflict;
}