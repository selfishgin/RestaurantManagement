using Application.AutoMapper;
using DAL.SqlServer;// Contains AddSqlServerServices extension and UnitOfWork
using MediatR;
using RestaurantManagement.Middlewares;
using Microsoft.Extensions.DependencyInjection;
using Repository.Common;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register MediatR by scanning the assembly containing your handlers
builder.Services.AddMediatR(typeof(Application.CQRS.Users.Handlers.Register.Handler).Assembly);

// Register AutoMapper and scan for MappingProfile(s)
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Register SQL Server services (using your extension method)
var conn = builder.Configuration.GetConnectionString("myconn");
builder.Services.AddSqlServerServices(conn);

// Register IUnitOfWork with its concrete implementation


var app = builder.Build();

// Use custom exception middleware (with Swagger bypass logic built in)
app.UseMiddleware<ExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

