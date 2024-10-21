using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaApi.Data;
using ClinicaApi.Models;
using ClinicaApi.Repositories.Interfaces;

namespace ClinicaApi.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ClinicaContext _context;
        public PatientRepository(ClinicaContext context){
            _context = context;
        }
        public async Task AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByCPFAsync(string cpf)
        {
            throw new NotImplementedException();
        }

        public Task<List<Patient>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Patient> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}