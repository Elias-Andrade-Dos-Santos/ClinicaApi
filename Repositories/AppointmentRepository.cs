using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaApi.Data;
using ClinicaApi.Models;
using ClinicaApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _context.Appointments
                                 .Include(a => a.Patient)  // Incluindo dados do paciente relacionado
                                 .ToListAsync();
        }

        public async Task<Appointment> GetByIdAsync(int id)
        {
            var res = await _context.Appointments
                                 .Include(a => a.Patient)
                                 .FirstOrDefaultAsync(a => a.Id == id);
            return res!;
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }
    }
}