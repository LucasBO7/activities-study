using MassTransit;
using ReportProcessor.Entities;

namespace ReportProcessor.Bus.Consumers;

// CONSUMER --> classe que consome o nosso RabbitMQ por meio do MassTransit
public class RelatorioSolicitadoEventConsumer : IConsumer<RelatorioSolicitadoEvent>
{
    private readonly ILogger<RelatorioSolicitadoEventConsumer> _logger;

    public RelatorioSolicitadoEventConsumer(ILogger<RelatorioSolicitadoEventConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<RelatorioSolicitadoEvent> context)
    {
        // Loggs
        // CorrelationIds
        // Indepotência

        var message = context.Message;
        _logger.LogInformation($"Processando relatório Id:{message.Id}, Nome: {message.Name}");

        await Task.Delay(1000);

        var relatorio = List.relatorios.FirstOrDefault(x => x.Id == message.Id);

        if (relatorio != null)
        {
            relatorio.Status = "Completo";
            relatorio.ProcessedTime = DateTime.Now;
        }

        _logger.LogInformation($"Relatório processado Id:{relatorio.Id}, Nome: {relatorio.Name}");
    }
}