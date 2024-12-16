using System.Threading.RateLimiting;
using FestivalShoppingApi.Data;
using FestivalShoppingApi.Domain.Contracts;
using FestivalShoppingApi.Domain.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FestivalShoppingContext>(opt 
    => opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IShoppingListService, ShoppingListService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddRateLimiter(opt =>
    {
        opt.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    
        opt.AddPolicy("Default", context => 
            RateLimitPartition.GetFixedWindowLimiter(
                partitionKey: context.Connection.RemoteIpAddress?.ToString(),
                factory: partition => new FixedWindowRateLimiterOptions
                {
                    PermitLimit = 15,
                    Window = TimeSpan.FromSeconds(10)
                }));
    
        opt.AddPolicy("Create-New-List", context => 
            RateLimitPartition.GetFixedWindowLimiter(
                partitionKey: context.Connection.RemoteIpAddress?.ToString(),
                factory: partition => new FixedWindowRateLimiterOptions
                {
                    PermitLimit = 1,
                    Window = TimeSpan.FromMinutes(5)
                }));
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
if (!app.Environment.IsDevelopment())
{
    app.UseRateLimiter();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
