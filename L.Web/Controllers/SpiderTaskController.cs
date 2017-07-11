using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace L.Web.Controllers
{
    public class SpiderTaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}