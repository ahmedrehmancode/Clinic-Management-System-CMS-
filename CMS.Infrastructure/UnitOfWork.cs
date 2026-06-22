using CMS.Application;
using CMS.Application.Interfaces.Repository;
using CMS.Domain.Entities;
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

        public IidentityRepository Identity { get; }

        public IUserRepository User { get; }

        public UnitOfWork(Mydbcontext context,IidentityRepository IdentityRepository,IUserRepository userRepository)
        {
            User = userRepository;
            Identity = IdentityRepository;
            _context = context;

        }

        //public IidentityRepository identityRepository => throw new NotImplementedException();

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
