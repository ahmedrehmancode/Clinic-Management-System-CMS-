using CMS.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application
{
    public interface IUnitOfWork
    {
      IClinicRepository ClinicDetail { get; }

        Task<int> SaveAsync();
    }
}
