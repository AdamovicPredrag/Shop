using AutoMapper;
using FluentValidation;
using OnlineShop.Application.Commands.Contacts;
using OnlineShop.Application.DataTransfer.Email;
using OnlineShop.Application.DataTransfer.User;
using OnlineShop.Application.Email;
using OnlineShop.Application.Requests.Contact;
using OnlineShop.Implementation.Validators.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Commands.Contact
{
    public class EfCommandContact : IContactCommand
    {
        private readonly IEmailSender _sender;
        private readonly ContactValidator _validator;

        public EfCommandContact(IEmailSender sender, ContactValidator validator)
        {
            _sender = sender;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "ContactSendEmailCommand";

        public void Execute(ContactRequest request)
        {
            _validator.ValidateAndThrow(request);

            var info = new EmailSendDto
            {
                Content= $"<html><body><h4>Send From: {request.SendFrom}</h4><p>Content :{request.Content}.</p></body></html>"
            };
            info.Subject = $"Title: {request.Subject}";
            info.SendTo = "predragadamovicict@gmail.com";
            _sender.Send(info);
        }
    }
}
