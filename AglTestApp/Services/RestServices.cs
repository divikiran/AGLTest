using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace AglTestApp.Services
{
    public class RestServices<T> : IRestServices<T> where T : class, new()
    {
        public T Item
        {
            get;
            set;
        } = new T();


        public string Url
        {
            get;
            set;
        } = "http://agl-developer-test.azurewebsites.net/people.json";
        
        public async Task<T> GetAllAsync()
        {
			try
			{
                if (CrossConnectivity.Current.IsConnected)
				{
					T result = default(T);

					using (var client = new HttpClient { BaseAddress = new Uri(Url) })
					{
						client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						var webApiUri = $"{Url}";
						Debug.WriteLine("URLPath : " + webApiUri);
						var response = await client.GetAsync(webApiUri);
						response.EnsureSuccessStatusCode();
						var getResult = await response.Content.ReadAsStringAsync();
						if (getResult != null)
						{
                            Item = result = JsonConvert.DeserializeObject<T>(getResult);
						}
						Debug.WriteLine("Return payload : " + result);
					}
					return result;
				}
				return null;
			}
			catch (Exception ex)
			{
				Debug.WriteLine("RestClient : " + ex.Message + " " + ex.StackTrace);
				throw;
			}
        }
    }
}
