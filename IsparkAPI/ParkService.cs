using System.Text.Json;
using System.Text.Json.Serialization;

namespace IsparkAPI
{
    public class ParkService(IHttpClientFactory factory) : IParkService
    {
        private readonly HttpClient client = factory.CreateClient("ispark");

        public async Task<ParkDetailDto?> GetDetailAsync(int id)
        {
            var response = await client.GetAsync("parkDetay?id=" + id);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<IEnumerable<ParkDetailDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, NumberHandling = JsonNumberHandling.AllowReadingFromString });
            return data?.FirstOrDefault();
        }

        public async Task<IEnumerable<ParkListDto>> GetListAsync()
        {
            var response = await client.GetAsync("park");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<IEnumerable<ParkListDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, NumberHandling = JsonNumberHandling.AllowReadingFromString });
            return data ?? [];
        }
    }
}
