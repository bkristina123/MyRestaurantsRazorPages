using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyRestaurants.Core;
using MyRestaurants.Data.Interfaces;

namespace MyRestaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }


        public IActionResult OnGet(int id)
        {
            var restaurant = restaurantData.GetById(id);

            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            Restaurant = restaurant;
            return Page();

        }

        public IActionResult OnPost(int id)
        {
            var restaurant = restaurantData.Delete(id);
            restaurantData.Commit();


            if(restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return RedirectToPage("./List");
        }


    }
}