using System.ComponentModel.DataAnnotations;
namespace Tpback1.Models.Dtos
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long? CelularNumber { get; set; }
        public long? TelephoneNumber { get; set; }
        public string? Description { get; set; }
    }
}
