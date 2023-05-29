using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Base
{
    public interface IUseCaselogger
    {
        void Log(IUseCase useCase, IApplicationActor actor, object useCaseData);
    }
}
