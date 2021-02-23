using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace AmazonSnsPrototype
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var config = new ConfigurationBuilder()
				.AddUserSecrets<AmazonSnsSettings>()
				.Build();
			
            var settings = config.GetSection("AmazonSNS").Get<AmazonSnsSettings>();
            Console.WriteLine($"TopicArn : '{settings.TopicArn}'.");

            string message = $"This test message was sent at {DateTime.Now}.";
            Console.WriteLine($"Message  : '{message}'.");

            var client = new AmazonSimpleNotificationServiceClient(region: RegionEndpoint.USWest1);
            Console.WriteLine();

            try
            {
                var response = await client.PublishAsync(new PublishRequest
                {
                    Message = message,
                    TopicArn = settings.TopicArn
                });
                Console.WriteLine($"Message has been sent to topic.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
		}
	}
}
