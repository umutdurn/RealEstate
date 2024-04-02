using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Features
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<RealEstate> RealEstate { get; set; }
    }
}
