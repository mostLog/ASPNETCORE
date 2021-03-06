﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using L.Application.Dto;
using L.Application.Services;

namespace L.Web.Controllers
{
    public class ChromeController : Controller
    {
        /// <summary>
        /// chrome信息推送服务
        /// </summary>
        private readonly IChromeService _chromeService;
        /// <summary>
        /// 
        /// </summary>
        public ChromeController(IChromeService chromeService)
        {
            _chromeService = chromeService;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取推送信息列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetPagedPushTexts(PushTextSearchInput input)
        {
            return Json(await _chromeService.GetPushTextPagedList(input));
        }
        /// <summary>
        /// 审核通过
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> CheckOk(CheckInput input)
        {
            int result = 0;
            try
            {
                await _chromeService.CheckOk(input);
            }
            catch (Exception)
            {

                result = -1;
            }
            return Json(result);
        }
    }
}