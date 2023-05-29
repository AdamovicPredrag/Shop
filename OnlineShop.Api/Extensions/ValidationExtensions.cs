using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Api.Extensions
{
    public static class ValidationExtensions
    {
        public static UnprocessableEntityObjectResult AsUnprocessableEntity(this IEnumerable<ValidationFailure> errors)
        {
            var errorObj = new
            {
                errors = errors.Select(x => new
                {
                    property = x.PropertyName,
                    error = x.ErrorMessage
                })
            };

            var result = new UnprocessableEntityObjectResult(errorObj);

            return result;
        }
    }
}
