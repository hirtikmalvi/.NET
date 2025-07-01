using Microsoft.EntityFrameworkCore;
using StudentManagementSystem_A1;
using StudentManagementSystem_A1.Configurations;
using StudentManagementSystem_A1.Models;
using StudentManagementSystem_A1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentManagementSystemDB"));
});
builder.Services.Configure<StudentSettings>(builder.Configuration.GetSection("StudentSettings"));
builder.Services.AddScoped<StudentService>();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();

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