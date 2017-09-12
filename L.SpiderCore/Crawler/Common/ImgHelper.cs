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
        private static void GetImageAndSave(string imgUri, string savePath)
        {
            var request = (HttpWebRequest)HttpWebRequest.Create(imgUri);
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.90 Safari/537.36";
            request.KeepAlive = true;
            request.Accept = "image/webp,image/apng,image/*,*/*;q=0.8";
            using (var response = request.GetResponse())
            {
                var stream = response.GetResponseStream();
                if (stream.Length != 0)
                {
                    using (var image = Image.FromStream(stream))
                    {
                        string saveUri = savePath + Path.GetFileName(imgUri);
                        try
                        {
                            image.Save(saveUri);
                        }
                        catch (Exception e)
                        {
                            throw new Exception("图片保存失败" + e.Message);
                        }
                    }
                }
            }
        }
    }
}