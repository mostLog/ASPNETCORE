using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Linq;

namespace L.LCore.Email
{
    /// <summary>
    /// 邮件发送对象
    /// </summary>
    public class EmailHelper
    {
        private static EmailConfig _emailConfig=new EmailConfig();
        private EmailHelper() { }
        public static void InitConfig(EmailConfig config)
        {
            _emailConfig = config;
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        public static bool SendEmail(string title, string content, IList<string> addresss)
        {
            if (addresss==null||addresss.Count==0)
            {
                throw new ArgumentException(nameof(addresss));
            }
            var msg=CreateMailMsg(title,content,addresss);
            var client=CreateSmtpClient();
            try
            {
                client.Send(msg);
            }
            catch (Exception)
            {
                return false;   
            }
            return true;
        }

        /// <summary>
        /// 创建邮件信息对象
        /// </summary>
        /// <returns></returns>
        private static MailMessage CreateMailMsg(string title,string content,IList<string> addresss)
        {
            MailMessage msg = new MailMessage();
            foreach (var address in addresss)
            {
                //收件人地址
                msg.To.Add(address);
            }
            //抄送人地址
            msg.CC.Add(_emailConfig.FromAddress);
            msg.From = new MailAddress(_emailConfig.FromAddress, "小白");
            msg.Subject = title;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.Body = content;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            return msg;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static SmtpClient CreateSmtpClient()
        {
            SmtpClient client = new SmtpClient();
            //SMTP服务器地址  
            client.Host = _emailConfig.Host;
            //SMTP端口
            client.Port = _emailConfig.Port;
            //启用SSL加密
            client.EnableSsl = true;
            //密码为授权码 
            client.Credentials = new System.Net.NetworkCredential(_emailConfig.FromAddress, _emailConfig.AuthCode);
            return client;
        }
    }
}
