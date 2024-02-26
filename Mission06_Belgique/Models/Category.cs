using System.ComponentModel.DataAnnotations;

namespace Mission06_Belgique.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId {  get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
