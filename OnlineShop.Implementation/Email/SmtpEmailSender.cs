using OnlineShop.Application.DataTransfer.Email;
using OnlineShop.Application.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        public void Send(EmailSendDto emailSendDto)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,              
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("predrag.adamovic.189.17@ict.edu.rs", "SdyGYHz5")
            };

            var message = new MailMessage("predrag.adamovic.189.17@ict.edu.rs", emailSendDto.SendTo);
            message.Subject = emailSendDto.Subject;
            message.Body = emailSendDto.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}
