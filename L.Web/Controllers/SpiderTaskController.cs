using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using L.Application.Services;
using L.Application.Services.Dto;
using L.Application.Dto;

namespace L.Web.Controllers
{
    public class SpiderTaskController : Controller
    {
        //爬虫服务
        private readonly ISpiderService _spiderService;
        public SpiderTaskController(ISpiderService spiderService)
        {
            _spiderService = spiderService;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 根据id获取实体
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public async Task<IActionResult> GetTaskById(BaseDto input)
        {
            return Json(await _spiderService.GetTaskById(input));
        }
        /// <summary>
        /// 添加或者更新任务 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddOrUpdateTask(AddOrEditTaskInputDto input)
        {
            int result = 0;
            try
            {
                await _spiderService.AddOrUpdateSpiderTask(input);
            }
            catch (Exception)
            {
                result = -1;
            }
            return Json(result);
        }
    }
}