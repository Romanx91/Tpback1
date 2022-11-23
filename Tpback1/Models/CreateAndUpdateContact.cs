using System.ComponentModel.DataAnnotations;
using Tpback1.Entities;

namespace Tpback1.Models
{
    public class CreateAndUpdateContact
    {
        [Required]
        public string Name { get; set; }
        public int? CelularNumber { get; set; }
        public int? TelephoneNumber { get; set; }
        public string Description = String.Empty;
        public User? User;
    }
}
