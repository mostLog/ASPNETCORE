using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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