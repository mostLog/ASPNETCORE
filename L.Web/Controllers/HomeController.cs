using L.Application;
using Microsoft.AspNetCore.Mvc;

namespace L.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly INoticeService _noticeService;

        public HomeController(
            INoticeService noticeService
            )
        {
            _noticeService = noticeService;
        }
        public IActionResult Index()
        {
            return View(_noticeService.GetNotices());
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
