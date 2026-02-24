using System.ComponentModel.DataAnnotations;

namespace FootwearInventory.Api.Models
{
    public class Footwear
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(100)]
        public required string Brand { get; set; }

        public int Size { get; set; }

        [MaxLength(50)]
        public required string Color { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}