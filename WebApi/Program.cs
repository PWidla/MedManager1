using FluentValidation;
using Application;
using Domain.Validators;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplication();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IValidator<User>, UserValidator>();
builder.Services.AddTransient<IValidator<Doctor>, DoctorValidator>();
builder.Services.AddTransient<IValidator<Patient>, PatientValidator>();
builder.Services.AddTransient<IValidator<Appointment>, AppointmentValidator>();
builder.Services.AddTransient<IValidator<MedicalRecord>, MedicalRecordValidator>();
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
