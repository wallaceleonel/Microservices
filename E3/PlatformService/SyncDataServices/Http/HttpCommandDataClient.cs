using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PlatformService.Dtos;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _HttpClient;

        public HttpCommandDataClient(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }
        public async Task SendPlatformToCommand(PlatformReadDto plat)
        {
            var HttpContent = new StringContent(
                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "apllication/json");

            var response = await _HttpClient.PatchAsync(" http://localhost:6000/api/c/platforms/", HttpContent);
        }
    }
}