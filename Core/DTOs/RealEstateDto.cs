using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class RealEstateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int M2 { get; set; }
        public int BuildingYear { get; set; }
        public int Floor { get; set; }
        public string Image { get; set; }
        public ICollection<Features>? Features { get; set; }
    }
}
