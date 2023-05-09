using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tpback1.Entities
{
    public class Call
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ContactId { get; set; }

        [ForeignKey("ContactId")]
        public Contacts Contact { get; set; }

        public int CountCall { get; set; }

        public DateTime TimeCall { get; set; }
    }

}
