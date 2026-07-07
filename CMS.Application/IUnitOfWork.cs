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

        IidentityRepository Identity { get; }
        IClinicRepository Clinic { get; }
        IUserRepository User { get; }

        Task<int> SaveAsync();
    }
}
