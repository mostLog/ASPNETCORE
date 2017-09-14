using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using L.Application.Services;
using L.Application.Dto;

namespace L.Web.Controllers
{
    public class ImagesController : Controller
    {
        /// <summary>
        /// 图片服务
        /// </summary>
        private readonly IImageService _iamgeService;
        public ImagesController(IImageService imageService)
        {
            _iamgeService = imageService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewImages()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetPagedList(ImageSearchInput input)
        {
            return Json(await _iamgeService.GetImagePagedList(input));
        }
    }
}