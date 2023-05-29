using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OnlineShop.Application.Base;
using OnlineShop.Application.Commands.Authorisation;
using OnlineShop.Application.Commands.Cart;
using OnlineShop.Application.Commands.Categories;
using OnlineShop.Application.Commands.Cities;
using OnlineShop.Application.Commands.Contacts;
using OnlineShop.Application.Commands.Order;
using OnlineShop.Application.Commands.Product;
using OnlineShop.Application.Commands.Shop;
using OnlineShop.Application.Commands.States;
using OnlineShop.Application.Commands.Users;
using OnlineShop.Application.Commands.WorkingHours;
using OnlineShop.Application.Email;
using OnlineShop.Application.Queries.Cart;
using OnlineShop.Application.Queries.Categories;
using OnlineShop.Application.Queries.Cities;
using OnlineShop.Application.Queries.Orders;
using OnlineShop.Application.Queries.Products;
using OnlineShop.Application.Queries.Shops;
using OnlineShop.Application.Queries.States;
using OnlineShop.Application.Queries.UseCaseLog;
using OnlineShop.Application.Queries.User;
using OnlineShop.Application.Queries.WorkingHours;
using OnlineShop.Implementation.Commands.Authoiisation;
using OnlineShop.Implementation.Commands.Cart;
using OnlineShop.Implementation.Commands.Categories;
using OnlineShop.Implementation.Commands.Cities;
using OnlineShop.Implementation.Commands.Contact;
using OnlineShop.Implementation.Commands.Orders;
using OnlineShop.Implementation.Commands.Product;
using OnlineShop.Implementation.Commands.Shop;
using OnlineShop.Implementation.Commands.States;
using OnlineShop.Implementation.Commands.Users;
using OnlineShop.Implementation.Commands.WorkingHours;
using OnlineShop.Implementation.Email;
using OnlineShop.Implementation.Log;
using OnlineShop.Implementation.Queries.Cart;
using OnlineShop.Implementation.Queries.Category;
using OnlineShop.Implementation.Queries.Cities;
using OnlineShop.Implementation.Queries.Order;
using OnlineShop.Implementation.Queries.Product;
using OnlineShop.Implementation.Queries.Shops;
using OnlineShop.Implementation.Queries.States;
using OnlineShop.Implementation.Queries.UseCaseLogs;
using OnlineShop.Implementation.Queries.Users;
using OnlineShop.Implementation.Queries.WorkingHours;
using OnlineShop.Implementation.Validators.Authorisation;
using OnlineShop.Implementation.Validators.Cart;
using OnlineShop.Implementation.Validators.Categories;
using OnlineShop.Implementation.Validators.Cities;
using OnlineShop.Implementation.Validators.Contact;
using OnlineShop.Implementation.Validators.Orders;
using OnlineShop.Implementation.Validators.Product;
using OnlineShop.Implementation.Validators.Shop;
using OnlineShop.Implementation.Validators.State;
using OnlineShop.Implementation.Validators.User;
using OnlineShop.Implementation.Validators.WorkingHours;
using System.Text;

namespace OnlineShop.Api.Core
{
    public static class Container
    {
        public static void AddValidators(this IServiceCollection services)
        {
            //Authorisation
            services.AddTransient<LoginUserValidator>();
            services.AddTransient<RegisterUserValidator>();

            //State validators
            services.AddTransient<AddStateValidator>();
            services.AddTransient<UpdateStateValidator>();
            services.AddTransient<DeleteStateValidator>();

            //Sategory validators
            services.AddTransient<AddCategoryValidator>();
            services.AddTransient<UpdateCategoryValidator>();
            services.AddTransient<DeleteCategoryValidator>();

            //Cities validators
            services.AddTransient<AddCityValidator>();
            services.AddTransient<UpdateCityValidator>();
            services.AddTransient<DeleteCityValidator>();

            //Shop Validators
            services.AddTransient<AddShopValidator>();
            services.AddTransient<UpdateShopValidator>();
            services.AddTransient<DeleteShopValidator>();

            //Product Validators
            services.AddTransient<AddProductValidator>();
            services.AddTransient<UpdateProductValidator>();
            services.AddTransient<DeleteProductValidator>();

            //Working Hours Validators
            services.AddTransient<AddWorkingHoursValidator>();
            services.AddTransient<UpdateWorkingHoursValidator>();
            services.AddTransient<DeleteWorkingHoursValidator>();

            //Cart Validators
            services.AddTransient<AddToCartValidator>();
            services.AddTransient<UpdateCartValidator>();
            services.AddTransient<DeleteCartValidator>();

            //Order Validator
            services.AddTransient<AddOrderValidator>();
            services.AddTransient<UpdateOrderValidator>();
            services.AddTransient<DeleteOrderValidator>();

            //User
            services.AddTransient<UpdateUserValidator>();
            services.AddTransient<UpdateCurrentUserValidator>();

            //Email 
            services.AddTransient<ContactValidator>();

        }

        public static void AddUseCases(this IServiceCollection services)
        {
            //Authorisation
            services.AddTransient<IRegisterUserCommand, EfCommandRegiterUser>();


            //Use case logger
            services.AddTransient<IUseCaselogger, DatabaseUseCaseLogger>();
            services.AddTransient<IExceptionLogger, DatabaseExceptionLogger>();

            //Email
            services.AddTransient<IEmailSender, SmtpEmailSender>();
            services.AddTransient<IContactCommand, EfCommandContact>();

            //State 
            services.AddTransient<IAddStateCommand, EfCommandAddState>();
            services.AddTransient<IUpdateStateCommand, EfCommandUpdateState>();
            services.AddTransient<IGetStatesQuery, EfGetStateQuery>();
            services.AddTransient<IDeleteStateCommand, EfCommandDeleteState>();

            //Category 
            services.AddTransient<IAddCategoryCommand, EfCommandAddCategory>();
            services.AddTransient<IUpdateCategoryCommand, EfCommandUpdateCategory>();
            services.AddTransient<IDeleteCategoryCommand, EfCommandDeleteCategory>();
            services.AddTransient<IGetCategoryQuery, EfGetCategoriesQuery>();

            //City
            services.AddTransient<IAddCityCommand, EfCommandAddCity>();
            services.AddTransient<IUpdateCityCommand, EfCommandUpdateCity>();
            services.AddTransient<IDeleteCityCommand, EfCommandDeleteCity>();
            services.AddTransient<IGetCityQuery, EfGetCityQuery>();

            //UseCaseLog
            services.AddTransient<IGetUseCaseLogQuery, EfCetUseCaseLogQuery>();

            //Shop
            services.AddTransient<IAddShopCommand, EfCommandAddShop>();
            services.AddTransient<IUpdateShopCommand, EfCommandUpdateShop>();
            services.AddTransient<IGetShopsQuery, EfGetShopsQuery>();
            services.AddTransient<IDeleteShopCommand, EfCoomandDeleteShop>();

            //Product
            services.AddTransient<IAddProductCommand, EfCommandAddProduct>();
            services.AddTransient<IUpdateProductCommand, EfCommandUpdateProduct>();
            services.AddTransient<IDeleteProductCommand, EfCommandDeleteProduct>();
            services.AddTransient<IGetProductQuery, EfGetProductQuery>();

            //WorkingHours 
            services.AddTransient<IAddWorkingHoursCommand, EfCommandAddWorkingHours>();
            services.AddTransient<IUpdateWorkingHoursCommand, EfCommandUpdateWorkingHours>();
            services.AddTransient<IDeleteWorkingHoursCommand, EfCommandDeleteWorkingHours>();
            services.AddTransient<IGetWorkingHoursQuery, EfGetWorkingHoursQuery>();

            //Cart
            services.AddTransient<IAddToCartCommand, EfCommandAddToCart>();
            services.AddTransient<IUpdateCartCommand, EfCommandUpdateCart>();
            services.AddTransient<IDeleteCartCommand, EfCommandDeleteCart>();
            services.AddTransient<IGetCartQuery, EfGetCartQuery>();

            //Order
            services.AddTransient<IAddOrdersCommand, EfCommandAddOrder>();
            services.AddTransient<IUpdateOrderCommand, EfCommandUpdateOrder>();
            services.AddTransient<IDeleteOrderCommand, EfCommandDeleteOrder>();
            services.AddTransient<IGetOrderQuery, EfGetOrdersQuery>();

            //User
            services.AddTransient<IGetUserQuery, EfGetUserQuery>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IUpdateUserCommand, EfCommandUpdateUser>();
            services.AddTransient<IUpdateCurrentUserCommand, EfCommandUpdateCurrentUser>();

        }

        public static void AddApplicationActor(this IServiceCollection services)
        {
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var header = accessor.HttpContext.Request.Headers["Authorization"];

                //Pristup payload-u
                var claims = accessor.HttpContext.User;

                if (claims == null || claims.FindFirst("UserId") == null)
                {
                    return new AnonymousActor();
                }

                var actor = new JwtActor
                {
                    Username = claims.FindFirst("Username").Value,
                    Id = Int32.Parse(claims.FindFirst("UserId").Value),
                    Identity = claims.FindFirst("Username").Value,
                    // "[1, 2, 3, 4, 5]"
                    AllowedUseCases = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCases").Value)
                };

                return actor;
            });
        }
        public static void AddJwt(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "AspIspit",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123ASDjfipoawopriqwop123124")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
