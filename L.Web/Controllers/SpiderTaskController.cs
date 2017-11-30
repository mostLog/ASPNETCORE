using L.Application.Dto;
using L.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace L.Web.Controllers
{
    public class SpiderTaskController : Controller
    {
        /// <summary>
        /// 爬虫服务
        /// </summary>
        private readonly ISpiderService _spiderService;

        public SpiderTaskController(
            ISpiderService spiderService
            )
        {
            _spiderService = spiderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 添加或者修改对话框页面
        /// </summary>
        /// <returns></returns>
        public IActionResult AddOrEditSpiderTask(int? id)
        {
            var task = new TaskEditDto();
            if (id.HasValue)
            {
                //获取任务信息
                task = _spiderService.GetTaskById(new BaseDto() { Id = id }).Result;
            }
            return View(task);
        }

        /// <summary>
        /// 获取爬虫列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetPagedList(TaskSearchInput input)
        {
            return Json(await _spiderService.GetSpiderTaskPagedList(input));
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
        public IActionResult AddOrUpdateTask(TaskAddOrEditInput input)
        {
            int result = 0;
            try
            {
                _spiderService.AddOrUpdateSpiderTask(input);
            }
            catch (Exception)
            {
                result = -1;
            }
            return Json(result);
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> DeleteTask(BaseDto input)
        {
            int result = 0;
            try
            {
                await _spiderService.DeleteSpiderTask(input);
            }
            catch (Exception)
            {
                result = -1;
            }
            return Json(result);
        }
    }
}