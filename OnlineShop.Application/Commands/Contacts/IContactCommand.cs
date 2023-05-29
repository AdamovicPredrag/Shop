using OnlineShop.Application.Base;
using OnlineShop.Application.Requests.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Commands.Contacts
{
    public interface IContactCommand : ICommand<ContactRequest>
    {
    }
}
