using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace L.SpiderCore.Crawler.Common
{
    public class ImgHelper
    {
        /// <summary>
        /// 获取图片 并保存本地
        /// </summary>
        /// <param name="imgUri">远程图片地址</param>
        /// <param name="savePath">保持本地路径</param>
        public static ImageBaseInfo GetImageAndSave(string imgUri, string savePath)
        {
            var request = (HttpWebRequest)HttpWebRequest.Create(imgUri);
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.90 Safari/537.36";
            request.KeepAlive = true;
            request.Accept = "image/webp,image/apng,image/*,*/*;q=0.8";
            try
            {
                using (var response = request.GetResponse())
                {
                    var stream = response.GetResponseStream();
                    using (var image = Image.FromStream(stream))
                    {
                        string fileName = Path.GetFileName(imgUri);
                        if (fileName.Contains("!"))
                        {
                            fileName = fileName.Substring(0, fileName.IndexOf("!"));
                        }
                        string saveUri = savePath + fileName;
                        image.Save(saveUri);
                        return new ImageBaseInfo()
                        {
                            Width = image.Width,
                            Height = image.Height
                        };
                    }
                }
            }
            catch (Exception e)
            {
                return new ImageBaseInfo();
            }
        }
    }

    public class ImageBaseInfo
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}