namespace ServicoProcessamento.Communication.Pesquisa.Responses;

public record ObterPesquisaResponse(string Id, string Codigo, DateTimeOffset? Inicio, DateTimeOffset? Fim, bool Ativa);