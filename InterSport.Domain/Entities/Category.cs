using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterSport.Domain.Entities
{
    [Table("Categorys")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
