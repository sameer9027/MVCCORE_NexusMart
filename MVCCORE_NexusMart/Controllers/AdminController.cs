using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCCORE_NexusMart.Models;

namespace MVCCORE_NexusMart.Controllers
{
    public class AdminController : Controller
    {
        private readonly NEXDBContext context;
        private readonly IWebHostEnvironment env;

        public AdminController(NEXDBContext context, IWebHostEnvironment env)
        {
            this.env = env;
            this.context = context;
        }

        async public Task<IActionResult> Home()
        {
            //<---------------------USE OF LOGGED IN SESSION STRING ADDED WHILE LOGIN --------------> 

            string session = HttpContext.Session.GetString("ADMIN_SESSION");
            if (session != null)
            {
                var products = await context.Tbl_Product.Include(p => p.Category).ToListAsync();
                return View(products);
            }

            return View("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("ADMIN_SESSION");
            return RedirectToAction("Home");
        }

        [HttpPost]
        public IActionResult Login(string pass, String email)
        {
            var Adata = context.Tbl_Admin.FirstOrDefault(item => item.Admin_Email == email);
            if (Adata.Admin_Password == pass)
            {
                //< -----------------USE-LIMIT Access to Dashbord(HOme)--------------------->
                HttpContext.Session.SetString("ADMIN_SESSION", Adata.Admin_Id.ToString());

                return RedirectToAction("Home");
            }
            else
            {
                ViewData["message"] = "Invalid Admin Login Credentials !";
                return View();
            }
        }

        // >---------------------------ADD CATEGORY-------------------------------------->
        [HttpGet]
        public async Task<IActionResult> Category()
        {
            string session = HttpContext.Session.GetString("ADMIN_SESSION");
            if (session == null)
            {
                return RedirectToAction("Login");
            }

            var CatList = await context.Tbl_Category.ToListAsync();
            return View(CatList);
        }

        [HttpPost]
        async public Task<IActionResult> Category(string name)
        {
            string session = HttpContext.Session.GetString("ADMIN_SESSION");
            if (session == null)
            {
                return RedirectToAction("Login");
            }

            if (!string.IsNullOrEmpty(name))
            {
                var cat = new Category { Category_Name = name };
                await context.Tbl_Category.AddAsync(cat);
                await context.SaveChangesAsync();
            }

            var CatList = await context.Tbl_Category.ToListAsync();
            return PartialView("_categoryList", CatList);
        }


        //----------------------------------DeleteCategory___________________________
        [HttpGet]
        async public Task<IActionResult> DeleteCategory(int id)
        {
            var session = HttpContext.Session.GetString("ADMIN_SESSION");
            if (session == null)
            {
                return RedirectToAction("Login");
            }

            var DelP = await context.Tbl_Category.FirstOrDefaultAsync(x => x.Category_Id == id);



            return View(DelP);

        }

        [HttpPost]
        [ActionName("DeleteCategory")]
        [Route("Admin/DeleteCategory")]
        async public Task<IActionResult> DeleteCategory(Category C)
        {
            // Additional improvement: ensure the entity is tracked before removal.
            var session = HttpContext.Session.GetString("ADMIN_SESSION");
            if (session == null)
            {
                return RedirectToAction("Login");
            }

            // Safely load the category from DB (avoids issues if only Id is posted)
            var existing = await context.Tbl_Category.FirstOrDefaultAsync(x => x.Category_Id == C.Category_Id);
            if (existing == null)
            {
                TempData["message"] = "Category not found";
                return RedirectToAction("Category");
            }

            context.Tbl_Category.Remove(existing);
            await context.SaveChangesAsync(); // FIX: await the asynchronous save

            TempData["message"] = "Category Deleted";
            return RedirectToAction("Category"); // Redirect to list instead of edit of deleted item
        }


        [HttpGet]
        public async Task<IActionResult> AddProducts()
        {
            string session = HttpContext.Session.GetString("ADMIN_SESSION");
            if (session == null)
            {
                return RedirectToAction("Login");
            }


            var products = await context.Tbl_Product
                .Include(p => p.Category)
                .OrderByDescending(p => p.Product_ID)
                .Take(10) // Show last 10 products
                .ToListAsync();

            ViewBag.RecentProducts = products;
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddProducts(ProductVM VP)
        {
            string session = HttpContext.Session.GetString("ADMIN_SESSION");
            if (session == null)
            {
                return RedirectToAction("Login");
            }

            if (ModelState.IsValid)
            {
                if (VP.ProductImageFile != null)
                {
                    // Generate unique filename
                    string NewName = Guid.NewGuid().ToString() + "_" + VP.ProductImageFile.FileName;
                    string wpath = Path.Combine(env.WebRootPath, "MyProdImage"); // Path on Web
                    string imagepath = Path.Combine(wpath, NewName);

                    // Create directory if it doesn't exist
                    if (!Directory.Exists(wpath))
                    {
                        Directory.CreateDirectory(wpath);
                    }

                    // Upload file
                    using (var stream = new FileStream(imagepath, FileMode.Create))
                    {
                        await VP.ProductImageFile.CopyToAsync(stream);
                    }
                    // Create Product entity - actual database model
                    Product P = new Product();
                    P.Product_Name = VP.Product_Name;
                    P.Product_Price = decimal.ToInt32(VP.Product_Price);
                    P.Product_Image = NewName; // Store filename in database
                    P.Product_Description = VP.Product_Description;
                    P.Category_Id = VP.Category_Id;

                    await context.Tbl_Product.AddAsync(P);
                    await context.SaveChangesAsync();

                    TempData["message"] = "Product Uploaded Successfully!";
                    return RedirectToAction("AddProducts");
                }
                else
                {
                    ModelState.AddModelError("ProductImageFile", "Please select an image file");
                }
            }
            // If we get here, there was an error - reload recent products
            var products = await context.Tbl_Product
                .Include(p => p.Category)
                .OrderByDescending(p => p.Product_ID)
                .Take(10)
                .ToListAsync();

            ViewBag.RecentProducts = products;
            ViewData["message"] = "Please check your information";

            return View(VP);
        }

        // ProductList action to view all products
        public async Task<IActionResult> _ProductList()
        {
            string session = HttpContext.Session.GetString("ADMIN_SESSION");
            if (session == null)
            {
                return RedirectToAction("Login");
            }

            var products = await context.Tbl_Product
                .Include(p => p.Category) // Include category data
                .ToListAsync();

            return View(products);
        }




        // GET: Show edit form
        public async Task<IActionResult> EditCategory(int id)
        {
            string session = HttpContext.Session.GetString("ADMIN_SESSION");
            if (session == null)
            {
                return RedirectToAction("Login");
            }

            var category = await context.Tbl_Category.FindAsync(id);
            if (category == null)
            {
                return RedirectToAction("Category");
            }

            return View(category);
        }

        // POST: Handle edit form submission
        [HttpPost]


        public async Task<IActionResult> EditCategory(Category ct)
        {
            string session = HttpContext.Session.GetString("ADMIN_SESSION"); //getting that is already setted by login  method 
            if (session == null)
            {
                return RedirectToAction("Login");
            }

            // Simple update
            context.Tbl_Category.Update(ct);
            await context.SaveChangesAsync();

            return RedirectToAction("Category");
        }
    }
}
