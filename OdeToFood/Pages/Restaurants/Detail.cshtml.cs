using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public Restaurant Restaurant { get; set; }

        [TempData]
        public string Message { get; set; }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetRestaurantsById(restaurantId);

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();

        }
    }
}
