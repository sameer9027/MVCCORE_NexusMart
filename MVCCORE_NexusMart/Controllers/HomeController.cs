using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCCORE_NexusMart.Models;
using MVCCORE_NexusMart.ViewModel;

namespace MVCCORE_NexusMart.Controllers
{
    public class HomeController : Controller
    {
        private readonly NEXDBContext context;

        public HomeController(NEXDBContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index(int categoryID = 0)
        {
            // Create view model to hold both products and categories
            var viewModel = new VMCategoryProduct();

            // Load all categories for the dropdown
            viewModel.Categories = await context.Tbl_Category.ToListAsync();
            ViewBag.Categories = viewModel.Categories; // For the layout dropdown

            // Load products based on category selection
            if (categoryID > 0)
            {
                // Filter by selected category
                viewModel.Products = await context.Tbl_Product
                    .Include(p => p.Category)
                    .Where(p => p.Category_Id == categoryID)
                    .ToListAsync();

                viewModel.SelectedCatagoryId = categoryID;
            }
            else
            {
                // Load all products
                viewModel.Products = await context.Tbl_Product
                    .Include(p => p.Category)
                    .ToListAsync();
            }

            return View(viewModel);
        }
    }
}
