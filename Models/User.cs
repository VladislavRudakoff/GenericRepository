using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class User : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public List<Order> Orders { get; set; } = new();
    }
}
