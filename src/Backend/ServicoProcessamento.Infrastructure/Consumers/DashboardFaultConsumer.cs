using MassTransit;
using Microsoft.Extensions.Logging;
using PesquisaPublica.Shared.Contracts.Events;

namespace ServicoProcessamento.Infrastructure.Consumers;

/// <summary>
/// /// Consumidor que lida com eventos de falha para <see cref="PesquisaRespondidaEvent"/>. <see cref="PesquisaRespondidaEvent"/>.
/// </summary>
/// <param name="logger">/// <param name="logger">A instância do logger para registrar mensagens.</param></param>
internal sealed class DashboardFaultConsumer(ILogger<DashboardFaultConsumer> logger)
    : IConsumer<Fault<PesquisaRespondidaEvent>>
{
    /// <summary>
    /// Consome o evento de falha e registra os detalhes.
    /// </summary>
    /// <param name="context">O contexto de consumo contendo o evento de falha.</param>
    public Task Consume(ConsumeContext<Fault<PesquisaRespondidaEvent>> context)
    {
        logger.LogInformation("Identificador da Mensagem: {MessageId}", context.Message.FaultedMessageId);
        logger.LogError("Exceção: {Message}", context.Message.Exceptions.FirstOrDefault()?.Message);

        return Task.CompletedTask;
    }
}