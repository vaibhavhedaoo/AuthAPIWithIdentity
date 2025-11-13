using AuthService.Data;
using AuthService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


//var builder = WebApplication.CreateBuilder(args);

////// Add DbContext
////builder.Services.AddDbContext<AppDBContext>(opt =>
////    opt.UseSqlite("DataSource=appdata.db"));

//var app = builder.Build();
//app.Run();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Authentication
builder.Services.AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme);


// Add Authorization
builder.Services.AddAuthorization();

// Configure DBContext
builder.Services.AddDbContext<AppDBContext>(opt => opt.UseSqlite("DataSource=appdata.db"));

// Add IdentityCore
builder.Services
    .AddIdentityCore<User>()
    .AddEntityFrameworkStores<AppDBContext>()
    .AddApiEndpoints();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable Identity APIs  just remove this comment
app.MapIdentityApi<User>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();