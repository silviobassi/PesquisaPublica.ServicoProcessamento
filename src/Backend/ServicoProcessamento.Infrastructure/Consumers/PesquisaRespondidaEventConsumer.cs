using MassTransit;
using Microsoft.Extensions.Logging;
using PesquisaPublica.Shared.Contracts.Events;

namespace ServicoProcessamento.Infrastructure.Consumers;

internal sealed class PesquisaRespondidaEventConsumer(ILogger<PesquisaRespondidaEventConsumer> logger)
    : IConsumer<PesquisaRespondidaEvent>
{
    public async Task Consume(ConsumeContext<PesquisaRespondidaEvent> context)
    {
        logger.LogWarning("Recebendo pesquisa...");
        await Task.Delay(10000);
        logger.LogInformation("PesquisaEntity recebida com sucesso: {Event}", context.Message);
    }
}