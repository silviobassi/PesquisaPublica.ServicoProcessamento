using MassTransit;

namespace ServicoProcessamento.Infrastructure.Consumers;

internal sealed class PesquisaRespondidaDefinition : ConsumerDefinition<PesquisaRespondidaEventConsumer>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<PesquisaRespondidaEventConsumer> consumerConfigurator,
        IRegistrationContext context)
    {
        consumerConfigurator.UseMessageRetry(retry => retry.Interval(3, TimeSpan.FromSeconds(3)));
    }
}