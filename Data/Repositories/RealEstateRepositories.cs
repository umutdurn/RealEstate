using Core.Model;
using Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class RealEstateRepositories : Repository<RealEstate>, IRealEstateRepository
    {
        public AppDbContext _appDbContext { get => _context as AppDbContext; }

        public RealEstateRepositories(AppDbContext context) : base(context)
        {
        }

        public List<RealEstate> GetlAllIncludeByFeatures(List<Features> features)
        {
            List<RealEstate> RE = new();

            foreach (var feature in features)
            {

                var result = _appDbContext.RealEstates.Where(x => x.Features.Any(y => y.Id == feature.Id)).Include(x => x.Features).ToList();

                bool reIf = true;

                foreach (var item in result)
                {
                    foreach (var re in RE)
                    {
                        if (re.Id == item.Id)
                        {
                            reIf = false;
                            break;
                        }
                    }
                }

                if (reIf)
                {
                    RE.AddRange(result);
                }
            }

            return RE;
        }

        public List<RealEstate> GetlAllIncludeByPriceRange(double min, double max)
        {
            if (max == 0)
            {
                max = 9999999999999999999;
            }

            return _appDbContext.RealEstates.Where(x => x.Price >= min && x.Price <= max).OrderBy(x => x.Price).ToList();
        }

        public List<RealEstate> GetlAllIncludeByTitle(string title)
        {
            var result = _appDbContext.RealEstates.Where(x => x.Title.ToLower().Contains(title.ToLower()));

            return result.ToList();
        }

        public List<RealEstate> GetlAllInclude()
        {
           return _appDbContext.RealEstates.Include(x => x.Features).ToList();
        }
    }
}
