using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaApi.Data
{
    public class ClinicaContext : DbContext
    {
        public ClinicaContext(DbContextOptions<ClinicaContext> options) : base(options) { }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Address> addresses{ get; set; }
        
    }
}