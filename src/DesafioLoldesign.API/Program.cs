
using System.Reflection;
using DesafioLoldesign.API.BL;
using DesafioLoldesign.API.BL.Interfaces;
using DesafioLoldesign.API.Data.Context;
using DesafioLoldesign.API.Data.Repositories;
using DesafioLoldesign.API.Domain.Data.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Desafio LolDesign - API", Version = "v1" });
});
builder.Services.AddDbContext<ChallengeContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPlansRepository, PlansRepository>();
builder.Services.AddScoped<IPlansBL, PlansBL>();
builder.Services.AddScoped<IRatesRepository, RatesRepository>();
builder.Services.AddScoped<IRatesBL, RatesBL>();
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DesafioLoldesign.API v1");
        c.RoutePrefix = string.Empty;

    });

}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
