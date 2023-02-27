using Microsoft.EntityFrameworkCore;
using PeopleList.Domain;
using PeopleList.Domain.Interfaces;
using PeopleList.EF.Repositories;
using PeopleListAPI.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "AllowOrigin",
        builder => {
            builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
        });
});

builder.Services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddTransient<IPeopleRespository, PeopleRepository>();
builder.Services.AddTransient<IUnitOfWork, IUnitOfWork>();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("PeopleListDb"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");

app.MapGet("/", () => @"
Welcome to People List API.
To use this api, proceed to /api/people.
The API verbs that can be used are: GET/PUT/POST/DELETE");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
