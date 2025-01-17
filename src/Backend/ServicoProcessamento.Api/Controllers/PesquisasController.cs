using Microsoft.AspNetCore.Mvc;
using ServicoProcessamento.Application.Pesquisa.CreatePesquisa;
using ServicoProcessamento.Application.Pesquisa.ObterPesquisaPorId;
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
        var response = await useCase.ExecuteAsync(request);
        return Created(string.Empty, response);
    }

    [HttpGet("{idPesquisa}/obter")]
    [ProducesResponseType(typeof(ObterPesquisaResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObterPesquisaPorIdAsync([FromServices] IObterPesquisaPorIdUseCase useCase,
        [FromRoute] string idPesquisa)
    {
        var response = await useCase.ExecuteAsync(idPesquisa);
        return Ok(response);
    }
}