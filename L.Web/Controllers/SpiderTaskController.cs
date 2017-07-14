using L.Application.Dto;
using L.Application.Services;
using L.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> AddOrUpdateTask(AddOrEditTaskInput input)
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
        /// <summary>
        /// 添加或者修改对话框页面
        /// </summary>
        /// <returns></returns>
        public IActionResult AddOrEditSpiderTask()
        {
            return View();
        }
    }
}