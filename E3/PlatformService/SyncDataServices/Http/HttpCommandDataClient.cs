using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PlatformService.Dtos;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _HttpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient ,IConfiguration configuration)
        {
            _HttpClient = httpClient;
            _configuration = configuration;
        }
        public async Task SendPlatformToCommand(PlatformReadDto plat)
        {
            var HttpContent = new StringContent(
                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "apllication/json");

            var response = await _HttpClient.PatchAsync($"{_configuration["CommandService"]}", HttpContent);

            if( response.IsSuccessStatusCode)
            {
                Console.WriteLine("-----> Sync POST to CommandService was OK!");
            }
            else
            {
                Console.WriteLine("-----> Sync POST to CommandService was NOT OK!");
            }
        }
    }
}