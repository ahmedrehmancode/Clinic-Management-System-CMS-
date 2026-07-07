using CMS.Application;
using CMS.Application.Interfaces.Repository;
using CMS.Domain.Entities;
using CMS.Infrastructre.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Repositories
{
    public class ClinicRepository : GenericRepository<Clinic> , IClinicRepository
    {
      
        public ClinicRepository(Mydbcontext context) : base(context)
        {
            
        }
    }
}
