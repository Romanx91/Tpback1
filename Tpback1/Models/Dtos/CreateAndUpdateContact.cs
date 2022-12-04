using System.ComponentModel.DataAnnotations;
using Tpback1.Entities;

namespace Tpback1.Models.Dtos
{
    public class CreateAndUpdateContact
    {
        [Required]
        public string Name { get; set; }
        public int? CelularNumber { get; set; }
        public int? TelephoneNumber { get; set; }
        public string Description = string.Empty;
        public User? User;
    }
}