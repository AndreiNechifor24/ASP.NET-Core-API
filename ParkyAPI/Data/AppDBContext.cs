﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkyAPI.Model;

namespace ParkyAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        public DbSet<NationalPark> NationalParks { get; set; }
        
        public DbSet<Trail> Trails { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
