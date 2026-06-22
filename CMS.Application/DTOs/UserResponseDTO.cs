using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.DTOs
{
    public class UserResponseDTO
    {
        public string UserId { get; set; } 
        public string FullName { get; set; } = string.Empty;
        public bool IsClinicAccount { get; set; }

        public string? UserName { get; set; }
        public string? Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

    }
}
