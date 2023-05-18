using QuanLyNongNghiepAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using QuanLyNongNghiepAPI.Services.User;
using QuanLyNongNghiepAPI.Services.Sensor;
using QuanLyNongNghiepAPI.Services.SensorData;
using QuanLyNongNghiepAPI.Utils.Email;
using QuanLyNongNghiepAPI.Utils.Context;
using QuanLyNongNghiepAPI.Services.Auth;
using QuanLyNongNghiepAPI.Services.Area;
using QuanLyNongNghiepAPI.Services.System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//service auth
builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
        };
        //options.SaveToken = true;
    });


//service db 
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));// shorthand getSection("ConnectionStrings")["DefaultConnection"]




//http context
builder.Services.AddHttpContextAccessor();



//Cors
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));


//service config
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddSingleton<IWebHostEnvironment>(builder.Environment);








//services

//Utils
builder.Services.AddTransient<ISendEmail, SendEmail>();
builder.Services.AddTransient<IHttpContextMethod, HttpContextMethod>();


//Service
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ISensorService, SensorService>();
builder.Services.AddTransient<ISensorDataService, SensorDataService>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IAreaService, AreaService>();
builder.Services.AddTransient<ISystemService, SystemService>();















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


app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();