using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterSport.Domain.Entities
{
    [Table("Brands")]
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
