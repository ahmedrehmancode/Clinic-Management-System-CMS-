using CMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Interfaces.Repository
{
    public interface IClinicRepository
    {
        Task<List<ClinicDetail>> GetAll();
        Task AddClinicAsync(ClinicDetail clinic);
        Task<ClinicDetail> GetById(int id);
        Task UpdateAsync(ClinicDetail clinic);
        Task DeleteByIDAsync(int Id);

        


    }
}
