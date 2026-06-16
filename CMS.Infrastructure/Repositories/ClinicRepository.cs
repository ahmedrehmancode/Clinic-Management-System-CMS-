using CMS.Application.Interfaces.Repository;
using CMS.Domain.Models;
using CMS.Infrastructre.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Repositories
{
   
    public  class ClinicRepository : IClinicRepository
    {
        
        private Mydbcontext _dbcontext;
        public ClinicRepository( Mydbcontext contex)
        {
            _dbcontext = contex;
            
        }

        public Task AddAsync(ClinicDetail clinic)
        {
            throw new NotImplementedException();
        }

        public Task AddClinicAsync(ClinicDetail clinic)
        {
            throw new NotImplementedException();
        }

        public async void ClinicRegister(ClinicDetail clinic)
        {
            //var data = await _dbcontext.clinicDetails.AddAsync(clinic);
            await _dbcontext.SaveChangesAsync();

        }

        public Task DeleteByIDAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClinicDetail>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ClinicDetail> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ClinicDetail clinic)
        {
            throw new NotImplementedException();
        }
    }
}
