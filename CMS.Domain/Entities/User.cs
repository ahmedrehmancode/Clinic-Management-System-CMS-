
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics.Contracts;

namespace CMS.Domain.Entities
{
    public class User
    {
        public string? Id { get; set; }
        public required string FullName { get; set; }
        public required string UserName { get; set; }
        public bool IsClinicAccount { get; set; }

        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }

    }
}
