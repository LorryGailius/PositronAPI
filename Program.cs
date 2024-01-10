using Microsoft.EntityFrameworkCore;
using PositronAPI.Context;
using PositronAPI.Services.AppointmentService;
using PositronAPI.Services.CouponService;
using PositronAPI.Services.CustomerService;
using PositronAPI.Services.DepartmentService;
using PositronAPI.Services.EmployeeService;
using PositronAPI.Services.ItemService;
using PositronAPI.Services.LoyaltyService;
using PositronAPI.Services.OrderService;
using PositronAPI.Services.ServicesService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add our services
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ILoyaltyService, LoyaltyService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ServicesService>();

// Add our DbContext
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
