using OnlineShop.Application.DataTransfer.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Email
{
    public interface IEmailSender
    {
        void Send(EmailSendDto emailSendDto);
    }
}
