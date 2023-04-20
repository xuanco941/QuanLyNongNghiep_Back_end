using QuanLyNongNghiepAPI.Models;
using Microsoft.EntityFrameworkCore;
using QuanLyNongNghiepAPI.Repository.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//db
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); // shorthand getSection("ConnectionStrings")["DefaultConnection"]
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(connectionString));



//services Repository
builder.Services.AddTransient<IUserRepository, UserRepository>();

//services




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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