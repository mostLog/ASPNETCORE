using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using L.Application.Services;
using Microsoft.AspNetCore.Hosting;

namespace L.Web.Controllers
{
    public class DbManagerController : Controller
    {
        /// <summary>
        /// 数据备份服务
        /// </summary>
        private readonly IDbManagerService _dbManagerService;

        public DbManagerController(IDbManagerService dbManagerService)
        {
            _dbManagerService = dbManagerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetTableData()
        {
            return Json(_dbManagerService.GetTableData());
        }

        /// <summary>
        /// 数据中数据备份
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddDataBackup(DateTime? dateTime)
        {
            int result = 0;
            try
            {
                _dbManagerService.AddDataBackup(dateTime);
            }
            catch
            {
                result = -1;
            }
            return Json(result);
        }
    }
}