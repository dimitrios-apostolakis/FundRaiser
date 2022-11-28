using Microsoft.AspNetCore.Mvc;

namespace FundRaiserWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
