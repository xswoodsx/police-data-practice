using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using policedata.Models;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using policedata.Data;
using policedata.ViewModel;

namespace policedata.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStreetLevelCrimesRepo _streetLevelCrimes;


        public HomeController(IStreetLevelCrimesRepo streetLevelCrimes)
        {
            _streetLevelCrimes = streetLevelCrimes;
        }

        [HttpGet]
        public async Task<ActionResult<AllCrimeInformation>> Index(string latitude, string longitude)
        {
            var allCrimes = await _streetLevelCrimes.GetAllStreetLevelCrimes(latitude, longitude);

            if (allCrimes != null)
            {
                return View(allCrimes);
            }
            else
            {
                return NotFound();
            }

            //[HttpGet]
            //public async Task<IActionResult> GetCrimeTypes()
            //{
            //    List<string> crimeTypes = new List<string>();
            //    using (var httpClient = new HttpClient())
            //    {
            //        using (var response = await httpClient.GetAsync("https://data.police.uk/api/crime-categories"))
            //        {
            //            string apiResponse = await response.Content.ReadAsStringAsync();
            //            crimeTypes = JsonConvert.DeserializeObject<List<string>>(apiResponse);
            //        }
            //    }
            //    return View(crimeTypes);

            //}

        }
    }
}



//List<CrimeDetails> crimesByLocation = new List<CrimeDetails>();
//IEnumerable<CrimeTypes> crimeTypes = new List<CrimeTypes>();
////IEnumerable<SelectListItem> listItems;


//var CrimeInformation = new AllCrimeInformation();

//using (var httpClient = new HttpClient())
//{
//    using (var allCrimesResponse = await httpClient.GetAsync($"https://data.police.uk/api/crimes-street/all-crime?lat={latitude}&lng={longitude}"))
//    using (var crimeTypesResponse = await httpClient.GetAsync("https://data.police.uk/api/crime-categories"))

//    {
//        string allCrimesApiResponse = await allCrimesResponse.Content.ReadAsStringAsync();
//        string crimeTypesApiResponse = await crimeTypesResponse.Content.ReadAsStringAsync();

//        crimesByLocation = JsonConvert.DeserializeObject<List<CrimeDetails>>(allCrimesApiResponse);
//        crimeTypes = JsonConvert.DeserializeObject<List<CrimeTypes>>(crimeTypesApiResponse);

//        //
//    }

//    //listItems = crimeTypes.Select(m => new SelectListItem { Text = m.name, Value = m.name });
//    CrimeInformation.CrimeDetails = crimesByLocation;

//    CrimeInformation.listItems = crimeTypes.Select(m => new SelectListItem { Text = m.name, Value = m.name });