using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Exceptions
{
    public class DateFromLessDateToException : Exception
    {
        public DateFromLessDateToException(DateTime DateFrom, DateTime DateTo)
           : base($"DateTo: {DateTo.Date} cant be before DateFrom: {DateFrom.Date}")
        {

        }
    }
}
