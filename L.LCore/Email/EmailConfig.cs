using System;
using System.Collections.Generic;
using System.Text;

namespace L.LCore.Email
{
    public class EmailConfig
    {
        /// <summary>
        /// 发件人地址
        /// </summary>
        public string FromAddress { get; set; } = "aasd147789@qq.com";
        /// <summary>
        /// 发件人登陆授权码
        /// </summary>
        public string AuthCode { get; set; } = "mjrtkhlrmvqhbfji";
        /// <summary>
        /// 主机
        /// </summary>
        public string Host { get; set; } = "smtp.qq.com";
        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; } = 587;


    }
}
