using Microsoft.EntityFrameworkCore;
using UnitOfWork.Design.Pattern.BusinessLayer;
using UnitOfWork.Design.Pattern.BusinessLayer.Models;
using UnitOfWork.Design.Pattern.BusinessLayer.RegisterServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TremContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("trem"))
);
builder.Services.AddScoped<CustomValidations>();
builder.Services.ExtendServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();