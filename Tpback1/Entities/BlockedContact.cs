
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

        public static BlockedContact FromContact(Contacts contact, User user)
        {
            return new BlockedContact
            {
                Contact = contact,
                ContactId = contact.Id,
                User = user,
                UserId = user.Id
            };
        }

        public static BlockedContact FromBlockedContact(BlockedContact blockedContact)
        {
            return new BlockedContact
            {
                Contact = blockedContact.Contact,
                ContactId = blockedContact.ContactId,
                User = blockedContact.User,
                UserId = blockedContact.UserId
            };
        }
    }
}


