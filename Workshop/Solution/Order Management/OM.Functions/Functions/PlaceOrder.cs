using BuildingBricks.OM;
using BuildingBricks.OM.Requests;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using TaleLearnCode;

namespace OM.Functions;

public class PlaceOrder
{

	private readonly ILogger _logger;
	private readonly IConfiguration _configuration;
	private readonly JsonSerializerOptions _jsonSerializerOptions;

	public PlaceOrder(
		ILoggerFactory loggerFactory,
		IConfiguration configuration,
		JsonSerializerOptions jsonSerializerOptions)
	{
		_logger = loggerFactory.CreateLogger<PlaceOrder>();
		_configuration = configuration;
		_jsonSerializerOptions = jsonSerializerOptions;
	}

	[Function("PlaceOrder")]
	public async Task<HttpResponseData> RunAsync(
		[HttpTrigger(AuthorizationLevel.Function, "post", Route = "orders")] HttpRequestData request)
	{
		try
		{
			PlaceOrderRequest placeOrderRequest = await request.GetRequestParametersAsync<PlaceOrderRequest>(_jsonSerializerOptions);
			OrderServices orderServices = new(_configuration);
			string orderId = await orderServices.PlaceOrderAsync(placeOrderRequest);
			return request.CreateCreatedResponse($"orders/{orderId}");
		}
		catch (Exception ex) when (ex is ArgumentNullException)
		{
			return request.CreateBadRequestResponse(ex);
		}
		catch (Exception ex)
		{
			_logger.LogError("Unexpected exception: {ExceptionMessage}", ex.Message);
			return request.CreateErrorResponse(ex);
		}
	}

}