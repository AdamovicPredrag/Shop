using Newtonsoft.Json;
using OnlineShop.Application.Base;
using OnlineShop.DataAccess;
using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Log
{
    public class DatabaseUseCaseLogger : IUseCaselogger
    {
        private readonly OnlineShopContext _context;
        public DatabaseUseCaseLogger(OnlineShopContext context)
        {
            _context = context;
        }

        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            _context.UseCaseLogs.Add(new UseCaseLog
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(useCaseData),
                UseCaseName = useCase.Name
            });
            _context.SaveChanges();
        }
    }
}
