using System;
using System.Collections.Generic;
using System.DrawingCore;
using System.Text;
using static QRCoder.QRCodeGenerator;

namespace L.LCore.Tools
{
    public class QRSettings
    {
        /// <summary>
        /// 文本或者url信息
        /// </summary>
        public string TextOrUrl { get; set; }
        /// <summary>
        /// 前景色
        /// </summary>
        public string ForegroundColor { get; set; } = "#000000";
        /// <summary>
        /// 背景色
        /// </summary>
        public string BackgroundColor { get; set; } = "#ffffff";
        /// <summary>
        /// 容错率
        /// </summary>
        public int FaultToleranceRate { get; set; } = 2;
        /// <summary>
        /// logo图片
        /// </summary>
        public Bitmap Icon { get; set; }
    }
}
