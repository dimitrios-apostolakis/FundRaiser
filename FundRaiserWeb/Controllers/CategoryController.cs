using FundRaiserWeb.Data;
using Microsoft.AspNetCore.Mvc;

namespace FundRaiserWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {   //retrieve all records, convert to a list, assign to variable
            var objCategoryList = _db.Categories.ToList();
            return View();
        }
    }
}
