using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using UniversityContracts.ViewModels;

namespace UniversityClientAppStorekeeper
{
	[Route("api/[controller]")]
	[ApiController]
	public class APIStorekeeper : ControllerBase
	{
		private static readonly HttpClient _client = new();
		public static UserViewModel? Client { get; set; } = null;
		public static void Connect(IConfiguration configuration)
		{
			_client.BaseAddress = new Uri(configuration["IPAddress"]);
			_client.DefaultRequestHeaders.Accept.Clear();
			_client.DefaultRequestHeaders.Accept.Add(new
		   MediaTypeWithQualityHeaderValue("application/json"));
		}
		public static T? GetRequest<T>(string requestUrl)
		{
			var response = _client.GetAsync(requestUrl);
			var result = response.Result.Content.ReadAsStringAsync().Result;
			if (response.Result.IsSuccessStatusCode)
			{
				return JsonConvert.DeserializeObject<T>(result);
			}
			else
			{
				throw new Exception(result);
			}
		}
		public static void PostRequest<T>(string requestUrl, T model)
		{
			var json = JsonConvert.SerializeObject(model);
			var data = new StringContent(json, Encoding.UTF8, "application/json");
			var response = _client.PostAsync(requestUrl, data);
			var result = response.Result.Content.ReadAsStringAsync().Result;
			if (!response.Result.IsSuccessStatusCode)
			{
				throw new Exception(result);
			}
		}
	}
}
