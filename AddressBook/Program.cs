using Microsoft.EntityFrameworkCore;
using BusinessLayer.Interface;
using RepositoryLayer.Context;
using ModelLayer.Mappings;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using BusinessLayer.Validators;
using ModelLayer.DTO;
using BusinessLayer.Service;
var builder = WebApplication.CreateBuilder(args);

// Add Database Context
builder.Services.AddDbContext<AddressBookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"))
);
// Add Validators
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddScoped<IValidator<CreateContactDTO>, CreateContactValidator>();
builder.Services.AddScoped<IValidator<UpdateContactDTO>, UpdateContactValidator>();
// Add AutoMapping
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddScoped<IAddressBookBL,AddressBookBL>();
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
