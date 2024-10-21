using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaApi.Data;
using ClinicaApi.Models;
using ClinicaApi.Repositories.Interfaces;

namespace ClinicaApi.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ClinicaContext _context;

        public AddressRepository (ClinicaContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Address address)
        {
            await _context.addresses.AddAsync(address);
            await _context.SaveChangesAsync();
        }

        public Task<Address> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Address address)
        {
            throw new NotImplementedException();
        }
    }
}