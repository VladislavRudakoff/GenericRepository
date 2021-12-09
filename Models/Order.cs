using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class Order : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int Price { get; set; }
    }
}
