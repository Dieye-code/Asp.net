using Microsoft.AspNetCore.Mvc;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class ProductController : Controller
    {

        DatabaseContext _databaseContext;

        public ProductController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IActionResult list()
        {
            _databaseContext.Products.ToList();
            return View();
        }
    }
}
