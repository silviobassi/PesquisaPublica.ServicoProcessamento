﻿using ServicoProcessamento.Communication.Pesquisa.Responses;

namespace ServicoProcessamento.Feature.Pesquisa.ObterPesquisaPorId;

public interface IObterPesquisaPorIdUseCase
{
    Task<ObterPesquisaResponse> ExecuteAsync(string idPesquisa);
}