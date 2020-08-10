using MyRestaurants.Core;
using System.Collections.Generic;

namespace MyRestaurants.Data.Interfaces
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant restaurant);
        int Commit();
        void Add(Restaurant restaurant);
        Restaurant Delete(int id);

    }
}
