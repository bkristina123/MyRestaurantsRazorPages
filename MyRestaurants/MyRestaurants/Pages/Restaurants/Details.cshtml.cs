using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyRestaurants.Core;
using MyRestaurants.Data.Interfaces;

namespace MyRestaurants
{
    public class DetailsModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant Restaurant { get; set; }
        [TempData]
        public string Message { get; set; }

        public DetailsModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int id)
        {
            Restaurant = restaurantData.GetById(id);

            if(Restaurant != null)
            {
                return Page();
            }

            return RedirectToPage("./NotFound");
        }
    }
}