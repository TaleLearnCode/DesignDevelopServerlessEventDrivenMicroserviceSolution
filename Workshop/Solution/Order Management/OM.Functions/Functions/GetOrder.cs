using BuildingBricks.OM;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using TaleLearnCode;

namespace OM.Functions;

public class GetOrder
{

	private readonly ILogger _logger;
	private readonly JsonSerializerOptions _jsonSerializerOptions;

	public GetOrder(
		ILoggerFactory loggerFactory,
		JsonSerializerOptions jsonSerializerOptions)
	{
		_logger = loggerFactory.CreateLogger<GetOrder>();
		_jsonSerializerOptions = jsonSerializerOptions;
	}

	[Function("GetOrder")]
	public async Task<HttpResponseData> RunAsync(
		[HttpTrigger(AuthorizationLevel.Function, "get", Route = "orders/{orderId}")] HttpRequestData request,
		string orderId)
	{
		try
		{
			ArgumentNullException.ThrowIfNull(orderId);
			return await request.CreateResponseAsync(await OrderServices.GetOrder(orderId), _jsonSerializerOptions);
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