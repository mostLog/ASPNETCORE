using System;
using System.Collections.Generic;
using System.DrawingCore;
using System.Text;
using QRCoder;

namespace L.LCore.Tools
{
    /// <summary>
    /// 二维码生成工具
    /// </summary>
    public class QRTool
    {
        /// <summary>
        /// 生成二维码图片
        /// </summary>
        /// <returns></returns>
        public static Bitmap GenerateQR(QRSettings settings)
        {
            try
            {
                //生成器
                var qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(settings.TextOrUrl, (QRCodeGenerator.ECCLevel)settings.FaultToleranceRate);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeAsBitmapByteArr = qrCode.GetGraphic(20, 
                    ColorHx16toRGB(settings.ForegroundColor), 
                    ColorHx16toRGB(settings.BackgroundColor), null);
                return qrCodeAsBitmapByteArr;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// 将16进制颜色通过RGB转换为Color
        /// </summary>
        /// <param name="strHxColor"></param>
        /// <returns></returns>
        public static Color ColorHx16toRGB(string strHxColor)
        {
            try
            {
                if (strHxColor.Length == 0)
                {//如果为空
                    return Color.FromArgb(0, 0, 0);//设为黑色
                }
                else
                {//转换颜色
                    return Color.FromArgb(int.Parse(strHxColor.Substring(1, 2), System.Globalization.NumberStyles.AllowHexSpecifier),
                        int.Parse(strHxColor.Substring(3, 2), System.Globalization.NumberStyles.AllowHexSpecifier),
                        System.Int32.Parse(strHxColor.Substring(5, 2), System.Globalization.NumberStyles.AllowHexSpecifier)
                        );
                }
            }
            catch
            {//设为黑色
                return Color.FromArgb(0, 0, 0);
            }
        }
    }
}
