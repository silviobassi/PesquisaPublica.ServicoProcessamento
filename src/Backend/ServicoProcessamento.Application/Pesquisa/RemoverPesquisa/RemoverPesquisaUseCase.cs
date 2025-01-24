﻿using E7.EasyResult;
using ServicoProcessamento.Communication.Errors;
using ServicoProcessamento.Domain.Pesquisa.Repositories;

namespace ServicoProcessamento.Application.Pesquisa.RemoverPesquisa;

public class RemoverPesquisaUseCase(IPesquisaRepository pesquisaRepository) : IRemoverPesquisaUseCase
{
    public async Task<Result> ExecuteAsync(string idPesquisa)
    {
        var pesquisa = await pesquisaRepository.ObterPesquisaPorIdAsync(idPesquisa);

        if (pesquisa is null) return new PesquisaNaoEncontradaError();

        if (pesquisa.EstaSendoRespondida) return new PesquisaEstaSendoRespondidaError();

        var pesquisaDeleted = await pesquisaRepository.RemoverPesquisaAsync(idPesquisa);

        return pesquisaDeleted is null ? new PesquisaNaoEncontradaError() : Result.Success();
    }
}