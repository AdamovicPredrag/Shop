using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Base
{
    public interface IQuerySingleResponse<TResult> : IUseCase
    {
        TResult Execute();
    }
}
