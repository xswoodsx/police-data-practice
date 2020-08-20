using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using policedata.Models;
using policedata.ViewModel;

namespace policedata.Data
{
    public class CallStreetLevelCrimes : IStreetLevelCrimesRepo
    {

        private readonly IHttpClientFactory _clientFactory;
        private AllCrimeInformation _crimeInformation = new AllCrimeInformation();

        public CallStreetLevelCrimes(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;

        }

        public async Task<AllCrimeInformation> GetAllStreetLevelCrimes(string latitude, string longitude)
        {
            if (String.IsNullOrEmpty(latitude) || String.IsNullOrEmpty(latitude))
            {
                latitude = "54.254110";
                longitude = "-0.435520";
            }
            {

            }
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://data.police.uk/api/crimes-street/all-crime?lat={latitude}&lng={longitude}");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string allCrimesApiResponse = await response.Content.ReadAsStringAsync();
                _crimeInformation.CrimeDetails = JsonConvert.DeserializeObject<List<CrimeDetails>>(allCrimesApiResponse);
                Console.WriteLine(_crimeInformation.CrimeDetails);

                return _crimeInformation;
            }
            else
            {
                return null;
            }

        }



    }
}

