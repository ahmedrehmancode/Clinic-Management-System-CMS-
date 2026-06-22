
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics.Contracts;

namespace CMS.Domain.Entities
{
    public class User
    {

        public string Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public bool? IsClinicAccount { get; set; }

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
