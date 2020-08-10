using Microsoft.EntityFrameworkCore;
using MyRestaurants.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurants.Data
{
    public class MyRestaurantsDbContext : DbContext
    {

        public MyRestaurantsDbContext(DbContextOptions<MyRestaurantsDbContext> options) : base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
