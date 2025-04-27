using ImageProcessorAPI.ExternalServices.RabbitMQ.Buses;
using ImageProcessorAPI.ExternalServices.RabbitMQ.Consumers;
using ImageProcessorAPI.ExternalServices.RabbitMQ.Interfaces;
using MassTransit;

namespace ImageProcessorAPI.Configurations;

public static class ServicesConfiguration
{
    public static void AddSwaggerConfigurationService(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public static void UseSwaggerService(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }

    public static void AddRabbitMQService(this IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();
        var config = provider.GetRequiredService<IConfiguration>();

        services.AddTransient<IPublishBus, PublishBus>();

        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.AddConsumer<UploadedImageEventConsumer>();

            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                ConfigureRabbitMQ(context, configurator);
            });
        });

        void ConfigureRabbitMQ(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configurator)
        {
            configurator.Host(new Uri(config["RabbitMQHost"]), host =>
            {
                host.Username("guest");
                host.Password("guest");
            });

            configurator.ConfigureEndpoints(context);
        }
    }
}