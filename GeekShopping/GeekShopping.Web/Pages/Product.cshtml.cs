using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeekShopping.Web.Pages
{
    public class ProductModel : PageModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageURL { get; set; }

        public void OnGet()
        {
        }
    }
}
