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
        //�������
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
        /// ����id��ȡʵ��
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public async Task<IActionResult> GetTaskById(BaseDto input)
        {
            return Json(await _spiderService.GetTaskById(input));
        }
        /// <summary>
        /// ��ӻ��߸������� 
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