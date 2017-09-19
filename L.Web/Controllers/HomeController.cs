using Microsoft.AspNetCore.Mvc;

namespace L.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(

            )
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        public IActionResult Main()
        {
            return View();
        }
       
        public IActionResult Error()
        {
            return View();
        }
    }
}