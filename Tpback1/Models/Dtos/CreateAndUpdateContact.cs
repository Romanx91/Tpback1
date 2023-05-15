using System.ComponentModel.DataAnnotations;
using Tpback1.Entities;

namespace Tpback1.Models.Dtos
{
    public class CreateAndUpdateContact
    {
        public string Name { get; set; }
        public long? CelularNumber { get; set; }
        public long? TelephoneNumber { get; set; }
        public string? Description { get; set; }
        
    }
}
