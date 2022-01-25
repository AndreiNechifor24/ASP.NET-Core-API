using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkyAPI.Data;
using ParkyAPI.Model;
using ParkyAPI.Repository.IRepositories;

namespace ParkyAPI.Repository.Repositories
{
    public class NationalParkRepository : INationalParkRepository
    {
        internal AppDBContext db;

        public NationalParkRepository(AppDBContext context)
        {
            this.db = context;
        }

        public bool CreateNationalPark(NationalPark model)
        {
            db.NationalParks.Add(model);
            return Save();
        }

        public bool DeleteNationalPark(NationalPark model)
        {
            db.NationalParks.Remove(model);
            return Save();
        }

        public bool DeleteNationalPark(int Id)
        {
            var park = GetNationalPark(Id);
            return DeleteNationalPark(park);
        }

        public NationalPark GetNationalPark(int Id)
        {
            return db.NationalParks.Find(Id);
        }

        public ICollection<NationalPark> GetNationalParks()
        {
            return db.NationalParks.OrderBy(park => park.Name).ToList();
        }

        public bool NationalParkExists(string name)
        {
            return db.NationalParks.Any(park => park.Name == name);
        }

        public bool NationalParkExists(int Id)
        {
            return db.NationalParks.Any(park => park.Id == Id);
        }

        public bool Save()
        {
            return db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateNationalPark(NationalPark model)
        {
            db.NationalParks.Update(model);
            return Save();

        }
    }
}
