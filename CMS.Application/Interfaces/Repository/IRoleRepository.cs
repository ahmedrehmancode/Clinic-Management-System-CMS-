using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Interfaces.Repository
{
    public interface IRoleRepository
    {
        Task<bool> CreateRole(string Role);
        Task<bool> As(string Role);

        
    }
}
