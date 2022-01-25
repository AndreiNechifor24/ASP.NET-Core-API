using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkyAPI.Model;

namespace ParkyAPI.Repository.IRepositories
{
    public interface INationalParkRepository
    {
        ICollection<NationalPark> GetNationalParks();
        
        NationalPark GetNationalPark(int Id);

        bool NationalParkExists(string name);

        bool NationalParkExists(int Id);

        bool CreateNationalPark(NationalPark model);

        bool UpdateNationalPark(NationalPark model);

        bool DeleteNationalPark(NationalPark model);

        bool DeleteNationalPark(int Id);

        bool Save();
    }
}
