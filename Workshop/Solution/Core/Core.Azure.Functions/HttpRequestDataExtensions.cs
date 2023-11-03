using Microsoft.Azure.Functions.Worker.Http;
using System.Collections.Specialized;
using System.Web;
using TaleLearnCode;

namespace BuildingBlocks.Azure.Functions;

public static class HttpRequestDataExtensions
{

	/// <summary>
	/// Gets the content location of the specified route.
	/// </summary>
	/// <param name="route">The route of the content location.</param>
	/// <returns>A <c>string</c> representing the content-location value.</returns>
	public static string GetContentLocation(this string route)
	{
		string httpProtocol;
		try
		{
			string? httpStatus = Environment.GetEnvironmentVariable("HTTPS");
			if (!string.IsNullOrWhiteSpace(httpStatus) && httpStatus.ToLower() == "on")
				httpProtocol = "https";
			else
				httpProtocol = "http";
		}
		catch
		{
			httpProtocol = "http";
		}

		if (route.StartsWith('/'))
			return $"{httpProtocol}://{Environment.GetEnvironmentVariable("WEBSITE_HOSTNAME")}{route}";
		else
			return $"{httpProtocol}://{Environment.GetEnvironmentVariable("WEBSITE_HOSTNAME")}/{route}";
	}

	/// <summary>
	/// Creates a created (HTTP status code 201) response with the Content-Location header value.
	/// </summary>
	/// <param name="httpRequestData">The <see cref="HttpRequestData"/> for this response.</param>
	/// <param name="route">The routing information for the content-location.</param>
	/// <returns>A <see cref="HttpResponseData"/> with a status of Created (201) and a Content-Location header value.</returns>
	public static HttpResponseData CreateResponse(this HttpRequestData httpRequestData, string route)
	{
		return httpRequestData.CreateCreatedResponse(GetContentLocation(route));
	}

	/// <summary>
	/// Gets the flag of whether to create an object if it does not already exists from the query string.
	/// </summary>
	/// <param name="httpRequestData">The <see cref="HttpRequestData"/> containing the request data.</param>
	/// <returns><c>True</c> if the CreateIfNotExists query string value is present and set to true; otherwise, <c>false</c>.</returns>
	public static bool CreateIfNotExists(this HttpRequestData httpRequestData)
	{
		try
		{
			NameValueCollection queryValues = HttpUtility.ParseQueryString(httpRequestData.Url.Query);
			if (queryValues.HasKeys() && queryValues.AllKeys.Contains("CreateIfNotExists"))
				return (queryValues["CreateIfNotExists"]?.ToLowerInvariant() == "true");
			else
				return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	/// <summary>
	/// Creates a created (HTTP status code 201) response with appropriate header values.
	/// </summary>
	/// <param name="httpRequestData">The <see cref="HttpRequestData"/> to use for building the response.</param>
	/// <param name="contentLocation">The location of the created object.</param>
	/// <param name="objectIdentifierName">Name of the type of object that was created.</param>
	/// <param name="objectIdentifierValue">Identifier of the created object.</param>
	/// <returns>A <see cref="HttpRequestData"/> representing the response to end back after an object has been created.</returns>
	public static HttpResponseData CreteCreatedResponse(this HttpRequestData httpRequestData, string contentLocation, string objectIdentifierName, string objectIdentifierValue)
	{
		HttpResponseData response = httpRequestData.CreateCreatedResponse(contentLocation);
		response.Headers.Add(objectIdentifierName, objectIdentifierValue);
		return response;
	}

	/// <summary>
	/// Gets the values from the request's query string.
	/// </summary>
	/// <param name="httpRequestData">The <see cref="HttpRequestData"/> containing the request information.</param>
	/// <returns>A <see cref="Dictionary{string, string}"/> representing the query string values for the request./returns>
	public static Dictionary<string, string> GetQueryStringValues(this HttpRequestData httpRequestData)
	{
		if (!string.IsNullOrWhiteSpace(httpRequestData.Url.Query))
		{
			NameValueCollection queryValues = HttpUtility.ParseQueryString(httpRequestData.Url.Query);
			if (queryValues.Count >= 1)
			{
				Dictionary<string, string> result = new();
				foreach (string key in queryValues.Keys)
				{
					string? queryStringValue = queryValues[key];
					if (!string.IsNullOrWhiteSpace(queryStringValue))
						result.TryAdd(key.ToLowerInvariant(), queryStringValue);
				}
				return result;
			}
		}
		return new();
	}

	/// <summary>
	/// Attempts to get the values from the requests' query string.
	/// </summary>
	/// <param name="httpRequestData">The <see cref="HttpRequestData"/> containing the request information.</param>
	/// <param name="queryStringValues">The resulting dictionary of query string values.</param>
	/// <returns><c>True</c> if the query string values are returned (they were present); otherwise, <c>false</c>.</returns>
	public static bool TryGetQueryStringValues(this HttpRequestData httpRequestData, out Dictionary<string, string> queryStringValues)
	{
		queryStringValues = GetQueryStringValues(httpRequestData);
		return queryStringValues != null;
	}

	/// <summary>
	/// Attempts to get the value of a specified request query string element.
	/// </summary>
	/// <param name="httpRequestData">The <see cref="HttpRequestData"/> containing the request information</param>
	/// <param name="key">The key of the query string element to attempt to get.</param>
	/// <param name="value">The resulting value of the attempted query string element.</param>
	/// <returns><c>True</c> if the specified query string value is returned.</returns>
	public static bool TryGetQueryStringValue(this HttpRequestData httpRequestData, string key, out string? value)
	{
		value = null;
		key = key.ToLowerInvariant();
		if (TryGetQueryStringValues(httpRequestData, out Dictionary<string, string> values) && values.ContainsKey(key))
			value = values[key];
		return value != null;
	}

	/// <summary>
	/// Gets the value of the specified request query string element.
	/// </summary>
	/// <param name="httpRequestData">The <see cref="HttpRequestData"/> containing the request information.</param>
	/// <param name="key">The key of the query string element to get.</param>
	/// <returns>A <c>string</c> representing the value of the specified query string element.</returns>
	public static string? GetQueryStringValue(this HttpRequestData httpRequestData, string key)
	{
		if (TryGetQueryStringValue(httpRequestData, key, out var queryStringValue))
			return queryStringValue;
		else
			return default;
	}

	public static bool GetBooleanQueryStringValue(this HttpRequestData httpRequestData, string key, bool defaultValue = false)
	{
		string? queryStringValue = httpRequestData.GetQueryStringValue(key);
		if (queryStringValue is not null)
			if (queryStringValue.ToLowerInvariant() == "true")
				return true;
			else if (queryStringValue.ToLowerInvariant() == "false")
				return false;
			else
				return defaultValue;
		return defaultValue;
	}

	public static int GetInt32QueryStringValue(this HttpRequestData httpRequestData, string key, int defaultValue = 0)
		=> int.TryParse(httpRequestData.GetQueryStringValue(key), out int results) ? results : defaultValue;

}