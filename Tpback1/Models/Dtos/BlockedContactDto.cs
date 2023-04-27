using System.ComponentModel.DataAnnotations;
using Tpback1.Entities;

namespace Tpback1.Models.Dtos
{
    public class BlockedContactDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long? CelularNumber { get; set; }
        public long? TelephoneNumber { get; set; }
        public bool IsBlocked { get; set; }
        public int ReceivedCallsCount { get; set; }
        public List<DateTime> ReceivedCallsTime { get; set; }
    }

}