using System.ComponentModel.DataAnnotations;
using Tpback1.Entities;

namespace Tpback1.Models.Dtos
{
    public class UpdateUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}