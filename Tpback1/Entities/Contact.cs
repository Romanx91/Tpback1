
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Text.Json.Serialization;
using NSubstitute.Core;

namespace Tpback1.Entities
{
    public class Contacts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public long? CelularNumber { get; set; }
        public long? TelephoneNumber { get; set; }
        public string? Description { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }
        public bool IsBlocked { get; set; }



    }
}
