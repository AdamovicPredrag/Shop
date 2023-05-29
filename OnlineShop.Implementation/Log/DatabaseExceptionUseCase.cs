using Azure;
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
    public class DatabaseExceptionLogger : IExceptionLogger
    {
        //private readonly OnlineShopContext _context;
        public DatabaseExceptionLogger()
        {
            //_context = context;
        }

        public void LogException(string resposne, int statusCode, string exception)
        {
            var newException = new ExceptionLog
            {
                Response = resposne,
                StatusCode = statusCode,
                Exception = exception
            };
            var _context = new OnlineShopContext();

            _context.ExceptionLogs.Add(newException);
            _context.SaveChanges();
        }
    }
}
