using MyRestaurants.Core;
using MyRestaurants.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRestaurants.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {

        public List<Restaurant> Restaurants { get; set; }

        public InMemoryRestaurantData()
        {
            var restaurant1 = new Restaurant
            {
                Id = 1,
                Name = "Amigos",
                Location = "Macedonian Square",
                Cuisine = CuisineType.Mexican
            };

            var restaurant2 = new Restaurant
            {
                Id = 2,
                Name = "Star Ocean",
                Location = "Chines Embassy",
                Cuisine = CuisineType.Asian
            };


            var restaurant3 = new Restaurant
            {
                Id = 3,
                Name = "Jagoda",
                Location = "Shirok Sokak",
                Cuisine = CuisineType.None
            };

            Restaurants = new List<Restaurant>
            {
                restaurant1,
                restaurant2,
                restaurant3
            };
        }

        public IEnumerable<Restaurant> GetByName(string name = null)
        {

            return Restaurants.Where(x => string.IsNullOrEmpty(name) || x.Name.StartsWith(name));
        }

        public Restaurant GetById(int id)
        {
            return Restaurants.FirstOrDefault(x => x.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = Restaurants.FirstOrDefault(x => x.Id == updatedRestaurant.Id);

            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public void Add(Restaurant restaurant)
        {
            restaurant.Id = Restaurants.Max(x => x.Id) + 1;
            Restaurants.Add(restaurant);
        }

        public Restaurant Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
