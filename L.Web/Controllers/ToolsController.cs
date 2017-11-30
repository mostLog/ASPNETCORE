using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using L.LCore.Tools;
using System.IO;
using System.DrawingCore.Imaging;
using System.DrawingCore;
using Microsoft.AspNetCore.Hosting;

namespace L.Web.Controllers
{
    /// <summary>
    /// 工具控制器
    /// </summary>
    public class ToolsController : Controller
    {

        private readonly IHostingEnvironment _hostingEnvironment;
        public ToolsController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        #region 二维码
        /// <summary>
        /// 二维码生成首页
        /// </summary>
        /// <returns></returns>
        public IActionResult QRCodeIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetQRImage(QRSettings settings)
        {
            try
            {
                string fileName = DateTime.Now.ToFileTime() + ".jpg";
                var qrImg = QRTool.GenerateQR(settings);
                qrImg.Save(_hostingEnvironment.ContentRootPath + @"\Images\" + fileName);
                return Content(@"/QRImages/" + fileName);
            }
            catch (Exception e)
            {

                throw;
            }
        }
        #endregion

        #region Cron表达式
        /// <summary>
        /// Cron表达式生成
        /// </summary>
        /// <returns></returns>
        public IActionResult CronIndex()
        {
            return View();
        } 
        #endregion
    }
}
