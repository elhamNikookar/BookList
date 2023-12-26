using System.ComponentModel.DataAnnotations;

namespace MyBookList.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(300)]
        public string? Author { get; set; }

        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [MaxLength(300)]
        public string? ISBN { get; set; }

    }
}
