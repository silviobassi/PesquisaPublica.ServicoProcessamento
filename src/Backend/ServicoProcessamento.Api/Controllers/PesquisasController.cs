using Microsoft.AspNetCore.Mvc;
using ServicoProcessamento.Application.Pesquisa.AtualizarPesquisa;
using ServicoProcessamento.Application.Pesquisa.CreatePesquisa;
using ServicoProcessamento.Application.Pesquisa.ObterPesquisaPorId;
using ServicoProcessamento.Application.Pesquisa.RemoverPesquisa;
using ServicoProcessamento.Communication.Requests;
using ServicoProcessamento.Communication.Responses;

namespace ServicoProcessamento.Api.Controllers;

public class PesquisasController : ServicoProcessamentoBaseController
{
    [HttpPost("criar")]
    [ProducesResponseType(typeof(CreatePesquisaResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreatePesquisaAsync([FromServices] ICreatePesquisaUseCase useCase,
        [FromBody] CreatePesquisaRequest request)
    {
        var result = await useCase.ExecuteAsync(request);
        return Created(string.Empty, result.Value);
    }

    [HttpGet("{idPesquisa}/obter")]
    [ProducesResponseType(typeof(ObterPesquisaResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObterPesquisaPorIdAsync([FromServices] IObterPesquisaPorIdUseCase useCase,
        [FromRoute] string idPesquisa)
    {
        var response = await useCase.ExecuteAsync(idPesquisa);
        return Ok(response);
    }

    [HttpPatch("atualizar")]
    public async Task<IActionResult> AtualizarPesquisaAsync(
        [FromServices] IAtualizarPesquisaUseCase useCase,
        [FromBody] AtualizarPesquisaRequest request)
    {
        var result = await useCase.ExecuteAsync(request);

        if (!result.IsFailure) return Ok();
        // Configura o erro no contexto para o middleware tratar
        HttpContext.Items["AppError"] = result.Error!;
        return new EmptyResult(); // O middleware assume o controle da resposta

    }

    [HttpDelete("{idPesquisa}/remover")]
    public async Task<IActionResult> RemoverPesquisaAsync([FromServices] IRemoverPesquisaUseCase useCase,
        [FromRoute] string idPesquisa)
    {
        await useCase.ExecuteAsync(idPesquisa);
        return NoContent();
    }
}