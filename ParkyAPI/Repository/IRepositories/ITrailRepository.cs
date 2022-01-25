using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkyAPI.Model;

namespace ParkyAPI.Repository.IRepositories
{
    public interface ITrailRepository
    {
        ICollection<Trail> GetTrails();

        ICollection<Trail> GetTrailsInNationalPark(int nationalParkId);

        Trail GetTrail(int Id);

        bool TrailExists(string name);

        bool TrailExists(int Id);

        bool CreateTrail(Trail model);

        bool UpdateTrail(Trail model);

        bool DeleteTrail(Trail model);

        bool DeleteTrail(int Id);

        bool Save();

    }
}
