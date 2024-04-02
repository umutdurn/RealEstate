using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class RealEstate
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public  double Price { get; set; }
        public int M2 { get; set; }
        public int BuildingYear { get; set; }
        public int Floor { get; set; }
        public string Image { get; set; }
        public ICollection<Features>? Features { get; set; }

    }
}
