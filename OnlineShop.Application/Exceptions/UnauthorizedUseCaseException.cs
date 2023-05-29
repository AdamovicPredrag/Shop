using OnlineShop.Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Exceptions
{
    public class UnauthorizedUseCaseException : Exception
    {
        public UnauthorizedUseCaseException(IUseCase useCase, IApplicationActor actor): base($"Actor whose id is {actor.Id} - {actor.Identity} tried to execute {useCase.Name}."){

        }
    }
}
