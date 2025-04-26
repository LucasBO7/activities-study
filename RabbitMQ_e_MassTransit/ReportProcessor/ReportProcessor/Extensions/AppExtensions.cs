using MassTransit;
using ReportProcessor.Bus;
using ReportProcessor.Bus.Consumers;
using ReportProcessor.Bus.Interfaces;

namespace ReportProcessor.Extensions;

public static class AppExtensions
{
   public static void AddRabbitMQService(this IServiceCollection services)
   {
        // Monta o service provider temporariamente
        var provider = services.BuildServiceProvider();
        var config = provider.GetRequiredService<IConfiguration>();

        services.AddTransient<IPublishBus, PublisBus>();

        services.AddMassTransit(busConfigurator =>
        {
            // Insere o nosso Consumer ao Bus
            busConfigurator.AddConsumer<RelatorioSolicitadoEventConsumer>();

            // Configura Mass Transit para utilizar o RabbitMQ
            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                ConfigureRabbitMQ(context, configurator);
            });
        });

        void ConfigureRabbitMQ(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configurator)
        {
            // Define a URL do RabbitMQ com as credenciais de acesso
            configurator.Host(new Uri(config["RabbitMQHost"]), host =>
            {
                host.Username("guest");
                host.Password("guest");
            });

            configurator.ConfigureEndpoints(context);
        }
   } 
}