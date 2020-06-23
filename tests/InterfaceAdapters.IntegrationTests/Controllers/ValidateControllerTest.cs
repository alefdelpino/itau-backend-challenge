using System.Text;
using System.Linq;
using System.Net.Http;
using Xunit;
using TestCases;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using FluentAssertions;
using Microsoft.Extensions.Hosting;
//using FrameworksAndDrivers.IntegrationTests;
using Microsoft.Extensions.Configuration;
//using System.IO;
using FrameworksAndDrivers;
using System.IO;
using EnterpriseBusinessRules.Entities;

namespace InterfaceAdapters.IntegrationTests.Controllers
{
    public class ValidateControllerTest
    {
        [Fact]
        public async void ValidatePassword()
        {       
            var rootPath = Path.GetFullPath("../../../../../");
            System.Console.WriteLine(rootPath);
            var webHostBuilder = new WebHostBuilder()
                .UseContentRoot(rootPath)
                .UseEnvironment("Development")
                .UseStartup<Startup>()
                .UseConfiguration(new ConfigurationBuilder()
                        .SetBasePath(rootPath)
                        .AddJsonFile("src/FrameworksAndDrivers/appsettings.json")
                        .Build()
                );
            using (var server = new TestServer(webHostBuilder))
            using (var client = server.CreateClient())
            {
                foreach(var test in ValidatePasswordTestCase.TestCases) {
                    var body = new StringContent(
                        JsonConvert.SerializeObject(test.Value), 
                        Encoding.Default, 
                        "application/json"
                    );
                    var response = await client
                        .PostAsync("/v1/validations/password", body);
                    response
                        .StatusCode
                        .Should()
                        .Be(test.Type == "Error" ? 422 : 200);
                }
            }
        }
    }
}