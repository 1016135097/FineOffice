using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace FineOffice.Common
{
    /// <summary>
    /// 发送邮件，利用属性传递相关参数
    /// </summary>
    public class MailSender
    {
        private string _UserName; 
        private string _UserPwd;
        private string _Server;
        private int _Port;
        private string _Recipient;
        private string _Subject;
        private string _Content;
        private string _Nickname;
        private string _SendAddress;

        /// <summary>
        /// 发送地址
        /// </summary>
        public string SendAddress
        {
            get { return _SendAddress; }
            set { _SendAddress = value; }
        }


        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname
        {
            get { return _Nickname; }
            set { _Nickname = value; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPwd
        {
            get { return _UserPwd; }
            set { _UserPwd = value; }
        }

        /// <summary>
        /// SMTP服务器
        /// </summary>
        public string Server
        {
            get { return _Server; }
            set { _Server = value; }
        }

        /// <summary>
        /// 端口
        /// </summary>
        public int Port
        {
            get { return _Port; }
            set { _Port = value; }
        }

        /// <summary>
        /// 收件人
        /// </summary>
        public string Recipient
        {
            get { return _Recipient; }
            set { _Recipient = value; }
        }

        /// <summary>
        /// 主题
        /// </summary>
        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        public MailSender() { }


        /// <summary>
        /// 发送邮件
        /// </summary>
        public void SendEmail(Dictionary<string, Stream> dictionary)
        {
            MailAddress sender = new MailAddress(this.SendAddress, this.Nickname, Encoding.UTF8);
            SmtpClient smtp = new SmtpClient(Server, Port);                     //Smtp传输协议
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(this.UserName, UserPwd);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;                   //邮件以网络方式发送到SMTP服务器

            MailAddress recipient = new MailAddress(this.Recipient);
            MailMessage mailobj = new MailMessage(sender, recipient);
            mailobj.Subject = Subject;
            mailobj.IsBodyHtml = true;                                         //邮件内容为HTML格式
            mailobj.Body = Content;
            mailobj.BodyEncoding = System.Text.Encoding.GetEncoding("GB2312"); //邮件内容编码格式
            mailobj.Priority = MailPriority.High;

            foreach (KeyValuePair<string, Stream> attach in dictionary)
            {
                mailobj.Attachments.Add(new Attachment(attach.Value,attach.Key));        //添加附件
            }
            smtp.Send(mailobj);
            mailobj.Attachments.Clear();
        }
    }
}
