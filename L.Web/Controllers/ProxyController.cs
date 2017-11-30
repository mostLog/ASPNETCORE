using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using L.Application.Services;
using L.Application.Dto;

namespace L.Web.Controllers
{
    /// <summary>
    /// 代理ip
    /// </summary>
    public class ProxyController : Controller
    {
        private readonly IProxyService _proxyService;
        public ProxyController(IProxyService proxyService)
        {
            _proxyService = proxyService;
        }
        /// <summary>
        /// 主页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 添加修改页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult AddOrEditProxy(int? id)
        {
            var proxy = new ProxyEditDto();
            if (id.HasValue)
            {
                _proxyService.GetProxyById(new BaseDto() { Id = id });
            }
            return View(proxy);
        }
        [HttpPost]
        public IActionResult AddOrUpdateProxy(ProxyAddOrEditInput input)
        {
            int result = 0;
            try
            {
                _proxyService.AddOrUpdateProxy(input);
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
        public async Task<IActionResult> DeleteProxy(BaseDto input)
        {
            int result = 0;
            try
            {
                await _proxyService.DeleteProxy(input);
            }
            catch (Exception)
            {
                result = -1;
            }
            return Json(result);
        }
        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetPagedList(ProxySearchInput input)
        {
            return Json(await _proxyService.GetProxyPagedList(input));
        }
        /// <summary>
        /// 验证代理是否可用
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> PingProxy()
        {
            return Json(await _proxyService.PingProxyIsAvailable());
        }
    }
}