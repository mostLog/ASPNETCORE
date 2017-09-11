using L.Application.Dto;
using L.Application.Services;
using L.HangFire.AspNetCore.Services;
using L.SpiderCore;
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
        /// <summary>
        /// hangfire服务
        /// </summary>
        private readonly IHangFireService _hangFireService;
        /// <summary>
        /// 爬虫管理
        /// </summary>
        private readonly SpiderManager _spiderManager;
        public SpiderTaskController(
            ISpiderService spiderService,
            IHangFireService hangFireService,
            SpiderManager spiderManager)
        {
            _spiderService = spiderService;
            _hangFireService = hangFireService;
            _spiderManager = spiderManager;
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
        public async Task<IActionResult> AddOrUpdateTask(TaskAddOrEditInput input)
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
        /// <summary>
        /// 启动循环任务
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void StartOrStopRecurrentTask(TaskRunOrStopInput input)
        {
            if (input==null)
            {
                throw new ArgumentException(nameof(input));
            }
            if (string.IsNullOrEmpty(input.SpiderId))
            {
                throw new ArgumentException(nameof(input.SpiderId));
            }
            //开启循环
            if (input.IsRecurrent)
            {
                if (string.IsNullOrEmpty(input.RecurrentCron))
                {
                    throw new ArgumentException(nameof(input.RecurrentCron));
                }
                //启动爬虫信息
                _spiderService.RunOrStopRecurrentTask(input.SpiderId, true);
                _hangFireService.AddRecurrentSchedule<SpiderManager>(input.SpiderId, s => s.RunTask(input.SpiderId, new SpiderCore.Crawler.SpiderConfig() { Uris = input.Uris }), input.RecurrentCron);
            }
            else
            {
                //关闭爬虫信息
                _spiderService.RunOrStopRecurrentTask(input.SpiderId, false);
                _hangFireService.DeleteRecurrentSchedule(input.SpiderId);
            }
        }
    }
}