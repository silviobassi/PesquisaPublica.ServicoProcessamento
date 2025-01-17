namespace ServicoProcessamento.Communication.Requests;

public record AtualizarPesquisaRequest(string Id, string Codigo, DateTime Inicio, DateTime Fim);