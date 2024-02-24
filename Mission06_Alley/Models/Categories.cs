using System.ComponentModel.DataAnnotations;

namespace Mission06_Alley.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
