using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using woolies.abstractions.Repositories;
using woolies.abstractions.Services;
using woolies.models;

namespace woolies.services
{
    public class ExerciseThreeService : IExerciseThreeService
    {
        private IWooliesTestEndpointClient _httpClient;

        public ExerciseThreeService(IWooliesTestEndpointClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<decimal> GetApiCalculatedTotal(TrolleyCalculatorRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var body = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await this._httpClient.HttpClient.PostAsync("trolleyCalculator", body);
            return 0m;
        }

        public decimal CalculateTotal(TrolleyCalculatorRequest request)
        {
            return 0m;
        }
    }
}
