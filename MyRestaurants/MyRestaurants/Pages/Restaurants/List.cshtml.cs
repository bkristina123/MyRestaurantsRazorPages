using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyRestaurants.Core;
using MyRestaurants.Data.Interfaces;
using System.Collections.Generic;

namespace MyRestaurants
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }


        public IEnumerable<Restaurant> Restaurants { get; set; }


        public ListModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public void OnGet()
        {
            Restaurants = restaurantData.GetByName(SearchTerm);
        }
    }
}