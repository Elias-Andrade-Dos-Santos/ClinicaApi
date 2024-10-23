using ClinicaApi.DTOs.AppointmentDTOs;
using ClinicaApi.DTOs.PatientDTOs;
using ClinicaApi.DTOs.validator.AppointmentValidatorDTO;
using ClinicaApi.DTOs.validator.PatientValidatorDTO;
using ClinicaApi.Repositories;
using ClinicaApi.Repositories.Interfaces;
using ClinicaApi.Services;
using ClinicaApi.Services.Interfaces;
using ClinicaAPI.DTOs.validator.PatientValidatorDTO;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Carregar as configurações de CORS do appsettings.json
var corsDevelopmentOrigins = builder.Configuration.GetSection("Cors:DevelopmentOrigins").Get<string[]>();
var corsProductionOrigins = builder.Configuration.GetSection("Cors:ProductionOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevelopmentCorsPolicy", builder =>
    {
        builder.WithOrigins(corsDevelopmentOrigins)  // Carrega as origens permitidas para Dev
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });

    options.AddPolicy("ProductionCorsPolicy", builder =>
    {
        builder.WithOrigins(corsProductionOrigins)   // Carrega as origens permitidas para Produção
               .WithMethods("GET", "POST")
               .WithHeaders("Authorization", "Content-Type")
               .AllowCredentials();
    });
});



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

builder.Services.AddScoped<IValidator<PatientPostDTO>, PatientPostDTOValidator>();
builder.Services.AddScoped<IValidator<PatientUpdateDTO>, PatientUpdateDTOValidator>();
builder.Services.AddScoped<IValidator<AppointmentPostDTO>, AppointmentPostDTOValidator>();
builder.Services.AddScoped<IValidator<AppointmentUpdateDTO>, AppointmentUpdateDTOValidator>();

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

if (app.Environment.IsDevelopment())
{
    app.UseCors("DevelopmentCorsPolicy");
}
else
{
    app.UseCors("ProductionCorsPolicy");
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
