using System.ComponentModel.DataAnnotations.Schema;

namespace InterSport.Domain.Entities
{
    [Table("Images")]
    public class Image
    {
        public int ImageId { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public string Base64 { get; set; }
        public string Extension { get; set; }
    }
}
