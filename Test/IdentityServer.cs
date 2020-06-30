using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Test
{
    [MemoryDiagnoser]
    public class IdentityServer
    {
        public static Identity Config { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();
            Config = config.GetSection("Identity").Get<Identity>();
        }

        [Benchmark]
        public void GetUserProfile()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Config.OAuth);
            var request = new HttpRequestMessage(HttpMethod.Get, Config.Host + IdentityQueries.Profile.GetUserProfileUrl);
            
            var response = client.SendAsync(request).GetAwaiter().GetResult();
            EnsureSuccess(response);
        }

        [Benchmark]
        public void UpdateUserProfile()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Config.OAuth);
            var request =
                new HttpRequestMessage(HttpMethod.Post, Config.Host + IdentityQueries.Profile.UpdateUserProfileUrl)
                {
                    Content = new StringContent(IdentityQueries.Profile.UpdateUserProfileQuery, Encoding.UTF8,
                        "application/json")
                };
            
            var response = client.SendAsync(request).GetAwaiter().GetResult();
            EnsureSuccess(response);
        }

        [Benchmark]
        public void ChangePasswordRequest()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Config.OAuth);
            var request = new HttpRequestMessage(HttpMethod.Post, Config.Host + IdentityQueries.ChangePassword.ChangePasswordRequestUrl);

            var response = client.SendAsync(request).GetAwaiter().GetResult();
            EnsureSuccess(response);
        }

        bool EnsureSuccess(HttpResponseMessage response)
        {
            
            var result = response.Content.ReadAsStringAsync().Result;
            var date = JsonConvert.DeserializeObject<ApiResponse>(result);

            return date.IsSuccess;
            return response.IsSuccessStatusCode;

        }
    }

}
