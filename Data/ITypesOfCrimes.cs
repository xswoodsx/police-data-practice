using System;
using System.Threading.Tasks;
using policedata.ViewModel;

namespace policedata.Data
{
    public interface ITypesOfCrimes
    {
        Task<AllCrimeInformation> GetAllTypesOfCrimes();
    }

}
