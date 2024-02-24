using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Alley.Models
{
    public class Submission
    {
        [Key]
        [Required]
        public int? MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public string Title { get; set; }
        [Required(ErrorMessage = "Enter a Title")]


        [Range(1888, 2024, ErrorMessage = "The year must be between 1888 and 2024")]
        public int Year { get; set; } = 2000;
        [Required(ErrorMessage = "Enter a Year")]


        public string? Director { get; set; }
        public string? Rating { get; set; }
        public int Edited { get; set; }
        [Required(ErrorMessage = "Has this movie been edited?")]
        public string? LentTo { get; set; }
        public int CopiedToPlex { get; set; }
        public string? Notes { get; set; }
    }
}
