using Microsoft.EntityFrameworkCore;
using PeopleListAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PeopleContext>(opt =>
    opt.UseInMemoryDatabase("PeopleList"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => @"
Welcome to People List API.
To use this api, proceed to /api/people.
The API verbs that can be used are: GET/PUT/POST/DELETE");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
