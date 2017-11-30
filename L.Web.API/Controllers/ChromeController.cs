using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using L.Application.Dto;
using L.Application.Services;

namespace L.Web.API.Controllers
{
    /// <summary>
    /// 测试
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class ChromeController : Controller
    {
        private readonly IChromeService _chromeService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="chromeService"></param>
        public ChromeController(IChromeService chromeService)
        {
            _chromeService = chromeService;
        }

        /// <summary>
        /// 接收推送信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReceivePushText(PushTextAddOrEditInput input)
        {
            int result = 0;
            string error = string.Empty;
            try
            {
                await _chromeService.AddOrUpdatePushText(input);
            }
            catch (Exception e)
            {

                return Json(e.Source+"---"+e.Message+ "---"+e.StackTrace);
            }
            return Json(result);
        }
    }
}
