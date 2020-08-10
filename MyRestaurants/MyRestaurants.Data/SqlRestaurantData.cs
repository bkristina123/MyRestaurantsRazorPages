using Microsoft.EntityFrameworkCore;
using MyRestaurants.Core;
using MyRestaurants.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyRestaurants.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly MyRestaurantsDbContext context;

        public SqlRestaurantData(MyRestaurantsDbContext context)
        {
            this.context = context;
        }

        public void Add(Restaurant restaurant)
        {
            context.Restaurants.Add(restaurant);
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);

            if(restaurant != null)
            {
                context.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return context.Restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetByName(string name)
        {
            return context.Restaurants.Where(x => string.IsNullOrEmpty(name) || x.Name.StartsWith(name));
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var entity = context.Restaurants.Attach(restaurant);
            entity.State = EntityState.Modified;
            return restaurant;
        }
    }
}
