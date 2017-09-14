using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using L.Application.Services;
using L.Application.Dto;

namespace L.Web.Controllers
{
    public class LoggerController : Controller
    {
        private readonly ILoggerService _loggerService;
        public LoggerController(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public IActionResult GetPagedList(LogSearchInput input)
        {
            return Json(_loggerService.GetLogPagedList(input));
        }
    }
}