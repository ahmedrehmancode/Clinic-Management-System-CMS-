using CMS.Domain.Entities;
using CMS.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Interfaces.Repository
{
    public interface IClinicRepository : IGenericRepository<Clinic>
    {
    }
}
