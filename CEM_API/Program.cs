global using System.Text;
global using CEM_API.Data;
global using CEM_API.Services;
global using CEM_API.Data.Models;
global using CEM_API.Data.DTOs;
global using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register app db context
builder.Services.AddDbContext<AppDbContext>(option =>
{
    var env = builder.Environment.IsDevelopment() ? "Local" : "Remote";
    option.UseSqlServer(builder.Configuration.GetConnectionString("Remote"));
});

// Register the authentiction handler
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecurityKey"]));

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        IssuerSigningKey = signingKey,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Issuer"],
        ValidAudience = builder.Configuration["Audience"]
    };
});

// Register services
builder.Services.AddTransient<AuthService>();
builder.Services.AddTransient<AdminUsersService>();
builder.Services.AddTransient<FinesService>();
builder.Services.AddTransient<OffensesService>();
builder.Services.AddTransient<PaymentsService>();
builder.Services.AddTransient<DefaultersService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication(); // Allow authentication flag
app.UseAuthorization();

app.MapControllers();

app.Run();
