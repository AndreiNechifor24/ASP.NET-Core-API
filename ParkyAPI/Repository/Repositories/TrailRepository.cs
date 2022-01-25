using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkyAPI.Data;
using ParkyAPI.Model;
using ParkyAPI.Repository.IRepositories;

namespace ParkyAPI.Repository.Repositories
{
    public class TrailRepository : ITrailRepository
    {
            internal AppDBContext db;

            public TrailRepository(AppDBContext context)
            {
                this.db = context;
            }

            public bool CreateTrail(Trail model)
            {
                db.Trails.Add(model);
                return Save();
            }

            public bool DeleteTrail(Trail model)
            {
                db.Trails.Remove(model);
                return Save();
            }

            public bool DeleteTrail(int Id)
            {
                var park = GetTrail(Id);
                return DeleteTrail(park);
            }

            public Trail GetTrail(int Id)
            {
                return db.Trails.Find(Id);
            }

            public ICollection<Trail> GetTrails()
            {
                return db.Trails.OrderBy(park => park.Name).ToList();
            }

            public bool TrailExists(string name)
            {
                return db.Trails.Any(park => park.Name == name);
            }

            public bool TrailExists(int Id)
            {
                return db.Trails.Any(park => park.Id == Id);
            }

            public bool Save()
            {
                return db.SaveChanges() >= 0 ? true : false;
            }

            public bool UpdateTrail(Trail model)
            {
                db.Trails.Update(model);
                return Save();

            }

        public ICollection<Trail> GetTrailsInNationalPark(int nationalParkId)
        {
            return db.Trails
                .Include(park => park.NationalPark)
                .Where(park => park.NationalParkId == nationalParkId)
                .ToList();
        }
    }
    }
