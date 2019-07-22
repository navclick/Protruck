using ProTrukRepo.Model;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Interface
{
   public interface ICityRepository
    {

        Task<Response> GetALLCities();

        Task<Response> AddCity(CityVM city);
        Task<Response> RemoveCity(CityVM city);
        Response GetCitiesSelectList();


    }
}
