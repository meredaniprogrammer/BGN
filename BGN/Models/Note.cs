using System.ComponentModel.DataAnnotations;

namespace BGN.Models
{
    public class Note
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
