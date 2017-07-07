using L.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = _noticeService.GetNoticeById();

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
