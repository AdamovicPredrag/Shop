using OnlineShop.Api.Core;
using OnlineShop.Application.Base;
using OnlineShop.Application.Requests.States;
using OnlineShop.DataAccess;
using OnlineShop.Implementation.Commands.States;
using OnlineShop.Implementation.Validators.State;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OnlineShopContext>();
builder.Services.AddTransient<UseCaseExecutor>();
builder.Services.AddTransient<JwtManager>();
builder.Services.AddTransient<AddStateValidator>();


builder.Services.AddHttpContextAccessor();

//From Container
builder.Services.AddUseCases();
builder.Services.AddValidators();
builder.Services.AddApplicationActor();
builder.Services.AddJwt();
builder.Services.AddAutoMapper(typeof(EfCommandAddState).Assembly);
//End From Container


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASPNedelja3Vezbe.Api v1"));
}

app.UseHttpsRedirection();
app.UseMiddleware<GlobalExceptionHandler>();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();


app.MapControllers();

app.Run();
