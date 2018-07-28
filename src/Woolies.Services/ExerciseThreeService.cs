using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Woolies.Abstractions.Repositories;
using Woolies.Abstractions.Services;
using Woolies.Models;

namespace Woolies.Services
{
    public class ExerciseThreeService : IExerciseThreeService
    {
        private IWooliesTestEndpointClient _httpClient;
        private readonly ILogger _logger;

        public ExerciseThreeService(IWooliesTestEndpointClient httpClient, ILogger logger)
        {
            this._httpClient = httpClient;
            this._logger = logger;
        }

        public async Task<decimal> GetApiCalculatedTotal(TrolleyCalculatorRequest request)
        {
            try
            {
                int result;
                var json = JsonConvert.SerializeObject(request);
                var body = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var response = await this._httpClient.HttpClient.PostAsync("trolleyCalculator", body);
                Int32.TryParse(await response.Content.ReadAsStringAsync(), out result);
                return result;
            }
            catch(HttpRequestException exception)
            {
                this._logger.LogError("Unable to complete post to resource {resource}", "trolleyCalculator");
                throw exception;
            }
        }
    }
}
