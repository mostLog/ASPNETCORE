using L.Application.Dto;
using L.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using L.Domain.Entities;

namespace L.Web.Controllers
{
    /// <summary>
    /// 小说控制器
    /// </summary>
    public class NovelController : Controller
    {
        private readonly INovelService _novelService;
        public NovelController(INovelService novelService)
        {
            _novelService = novelService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewArticle(int id)
        {
            var article= _novelService.GetArticleById(id);
            ViewBag.Article = article.Content;
            return View();
        }
        /// <summary>
        /// 获取小说列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetPagedList(NovelSearchInput input)
        {
            return Json(await _novelService.GetNovelPagedList(input));
        }
        /// <summary>
        /// 获取小说章节列表
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetAritcles(BaseDto input)
        {
            return Json(new {
                Code=0,
                Data=await _novelService.GetArticlesByNovelId(input)
            });
        }
        /// <summary>
        /// 开启Email推送
        /// </summary>
        public void StartOrStopEmailPush(NovelSearchInput input)
        {
            if (input==null)
            {
                throw new ArgumentException(nameof(input));
            }
            _novelService.UpdateNovel(new Novel() { Id = input.Id.Value, IsOpenEmail = input.IsOpenEmail });
        }
    }
}