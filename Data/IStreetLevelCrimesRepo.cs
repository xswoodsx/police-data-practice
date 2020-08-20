using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using policedata.Models;
using policedata.ViewModel;

namespace policedata.Data
{
    public interface IStreetLevelCrimesRepo
    {
        Task<AllCrimeInformation> GetAllStreetLevelCrimes(string latitude, string longitude);
    }
}
