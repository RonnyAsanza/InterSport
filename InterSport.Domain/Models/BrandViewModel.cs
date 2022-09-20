using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterSport.Domain.Models
{
    public class BrandViewModel
    {
        public int BrandId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
