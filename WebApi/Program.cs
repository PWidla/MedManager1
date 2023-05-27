using Application;
using Domain.Entities;
using Domain.Validators;
using FluentValidation;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddApplication();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IValidator<User>, UserValidator>();
builder.Services.AddTransient<IValidator<Doctor>, DoctorValidator>();
builder.Services.AddTransient<IValidator<Patient>, PatientValidator>();
builder.Services.AddTransient<IValidator<Appointment>, AppointmentValidator>();
builder.Services.AddTransient<IValidator<Prescription>, PrescriptionValidator>();


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
