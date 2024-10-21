using ClinicaApi.DTOs.PatientDTOs;
using ClinicaApi.DTOs.validator.PatientValidatorDTO;
using ClinicaApi.Repositories;
using ClinicaApi.Repositories.Interfaces;
using ClinicaApi.Services;
using ClinicaApi.Services.Interfaces;
using ClinicaAPI.DTOs.validator.PatientValidatorDTO;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar dependências
builder.Services.AddScoped<IPatientService, PatientService>();

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

builder.Services.AddScoped<IValidator<PatientPostDTO>, PatientPostDTOValidator>();
builder.Services.AddScoped<IValidator<PatientUpdateDTO>, PatientUpdateDTOValidator>();

builder.Services.AddDbContext<ClinicaApi.Data.ClinicaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
