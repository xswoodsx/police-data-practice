using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using policedata.Models;
using policedata.ViewModel;

namespace policedata.Data
{
    public class CallTypesOfCrimes
    {
        private readonly IHttpClientFactory _clientFactory;
        private AllCrimeInformation _crimeInformation = new AllCrimeInformation();
        public CallTypesOfCrimes(IHttpClientFactory clientFactory)

        {
            _clientFactory = clientFactory;

        }

        public async Task<AllCrimeInformation> GetAllTypesOfCrimes()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://data.police.uk/api/crime-categories");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string allCrimesApiResponse = await response.Content.ReadAsStringAsync();
                _crimeInformation.CrimeTypes = JsonConvert.DeserializeObject<List<CrimeTypes>>(allCrimesApiResponse);

                return _crimeInformation;
            }
            else
            {
                return null;
            }
        }
    }
}
