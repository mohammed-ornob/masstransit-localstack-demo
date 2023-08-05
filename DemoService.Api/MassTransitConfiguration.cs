using CloudEventify.MassTransit;
using MassTransit;
using MassTransit.Serialization.JsonConverters;

namespace DemoService.Api;

public static class MassTransitConfiguration
{
    public static void AddPublisher(this WebApplicationBuilder self)
    {
        self.Services.AddMassTransit(x =>
        {
            x.UsingAmazonSqs((_, cfg) =>
            {
                cfg.UseCloudEvents()
                    .WithJsonOptions(options => options.Converters.Add(new SystemTextJsonConverterFactory()))
                    .WithTypes(t => t
                        .Map<DemoMessage>("DemoMessage"));
                
                cfg.Host("eu-central-1", h =>
                {
                    h.AccessKey("<aws-iam-access-key>");
                    h.SecretKey("<aws-iam-secret-key>");
                });

                cfg.Message<DemoMessage>(mtc =>
                {
                    mtc.SetEntityName("example-topic");
                });
            });
        });
    }
}