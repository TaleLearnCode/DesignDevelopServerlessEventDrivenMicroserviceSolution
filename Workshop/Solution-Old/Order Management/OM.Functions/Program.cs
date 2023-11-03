using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using System.Text.Json.Serialization;

IHost host = new HostBuilder()
	.ConfigureAppConfiguration(builder =>
	{
		builder.AddAzureAppConfiguration(Environment.GetEnvironmentVariable("AppConfigConnectionString")!);
	})
	.ConfigureFunctionsWorkerDefaults()
	.ConfigureServices(s =>
	{
		s.AddSingleton((s) =>
		{
			return new JsonSerializerOptions()
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
				DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
				WriteIndented = true
			};
		});
	})
	.Build();

host.Run();