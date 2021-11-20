using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Net.Http.Headers;
using NearX.Models;

namespace NearX.Services
{
    public class OverpassService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public OverpassService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<OverpassResult> GetCafesAsync(string amenity, string box)
        {
            var search = $"node[amenity= {amenity}]{box};" +
                         $"way[amenity= {amenity}]{box};" +
                         $"relation[amenity= {amenity}]{box};";

            var overpassURL = $@"https://www.overpass-api.de/api/interpreter?data=[out:json];(" + search+ ");out center;";
           // var overpassURL = $@"https://www.overpass-api.de/api/interpreter?data=[out:xml];(" + search + ");out center;";

            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                overpassURL)
            {
                //Headers =
                //{
                //    { HeaderNames.Accept, "application/vnd.github.v3+json" },
                //    { HeaderNames.UserAgent, "HttpRequestsSample" }
                //}
            };
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.GetStringAsync(overpassURL);

            OverpassResult result = JsonSerializer.Deserialize<OverpassResult>(httpResponseMessage);



            return result;

        }
    }
}
