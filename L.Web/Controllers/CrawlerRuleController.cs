using Microsoft.AspNetCore.Mvc;

namespace L.Web.Controllers
{
    public class CrawlerRuleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IActionResult AddOrEditRule()
        {
            return View();
        }
    }
}