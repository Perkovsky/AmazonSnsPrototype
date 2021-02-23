using Microsoft.Extensions.Configuration;
using System;

namespace AmazonSnsPrototype
{
	class Program
	{
		static void Main(string[] args)
		{
			var config = new ConfigurationBuilder()
				.AddUserSecrets<AmazonSnsSettings>()
				.Build();
			var settings = config.GetSection("AmazonSNS").Get<AmazonSnsSettings>();

			Console.WriteLine($"AmazonSNS:Url = '{settings.Url}'.");
		}
	}
}
