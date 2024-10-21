using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaApi.Models;

namespace ClinicaApi.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address> GetByIdAsync(int id);
        Task AddAsync(Address address);
        Task UpdateAsync(Address address);
    }
}