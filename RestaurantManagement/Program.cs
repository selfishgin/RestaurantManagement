using Application;
using Application.AutoMapper;
using Application.Security;
using DAL.SqlServer;// Contains AddSqlServerServices extension and UnitOfWork
using MediatR;
using Microsoft.AspNetCore.Cors.Infrastructure;
using RestaurantManagement.Infrastructure;
using RestaurantManagement.Middlewares;
using RestaurantManagement.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IUserContext, HttpUserContext>();
builder.Services.AddApplicationServices();
builder.Services.AddMediatR(typeof(Application.CQRS.Users.Handlers.Register.Handler).Assembly);
builder.Services.AddAuthenticationService(builder.Configuration);
//builder.Services.ConfigureCors();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

var conn = builder.Configuration.GetConnectionString("myconn");
builder.Services.AddSqlServerServices(conn);
builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<Microsoft.AspNetCore.Cors.Infrastructure.CorsMiddleware>();
app.UseCors();
app.UseMiddleware<ExceptionHandlerMiddleware>();
//app.UseMiddleware<RateLimitMiddleware>(2 , TimeSpan.FromMinutes(1));

app.MapControllers();

app.Run();