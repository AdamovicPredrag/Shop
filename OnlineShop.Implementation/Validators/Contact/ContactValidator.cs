using FluentValidation;
using OnlineShop.Application.Requests.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Validators.Contact
{
    public class ContactValidator : AbstractValidator<ContactRequest>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Content).NotEmpty();

            RuleFor(x => x.SendFrom).NotEmpty().EmailAddress();

            RuleFor(x => x.Subject).NotEmpty();
        }
    }
}
