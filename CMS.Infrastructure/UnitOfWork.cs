using CMS.Application;
using CMS.Application.Interfaces.Repository;
using CMS.Domain.Models;
using CMS.Infrastructre.Data;
using CMS.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Mydbcontext _context;

        public IClinicRepository ClinicDetail { get; }
        public UnitOfWork(Mydbcontext context,IClinicRepository clinicRepository)
        {

            _context = context;
            ClinicDetail = clinicRepository;



        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
