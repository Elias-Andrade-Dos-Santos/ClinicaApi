using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaApi.Data;
using ClinicaApi.Models;
using ClinicaApi.Repositories.Interfaces;

namespace ClinicaApi.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ClinicaContext _context;

        public AppointmentRepository(ClinicaContext context)
        {
           _context = context;
        }

        public async Task AddAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Appointment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}