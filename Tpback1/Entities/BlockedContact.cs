
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tpback1.Entities
{
    public class BlockedContact
    {
        public int Id { get; set; }
        public Contacts Contact { get; set; }
        public int ContactId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }


    }
}


