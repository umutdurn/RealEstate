using Core.Model;
using Core.Repository;
using Core.Service;
using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class RealEstateService : Service<RealEstate>, IRealEstateService
    {
        public RealEstateService(IUnitOfWork unitOfWork, IRepository<RealEstate> repository) : base(unitOfWork, repository)
        {
        }

        public List<RealEstate> GetlAllInclude()
        {
            return _unitOfWork.RealEstate.GetlAllInclude();
        }

        public List<RealEstate> GetlAllIncludeByFeatures(List<Features> features)
        {
            return _unitOfWork.RealEstate.GetlAllIncludeByFeatures(features);
        }

        public List<RealEstate> GetlAllIncludeByPriceRange(double min, double max)
        {
            return _unitOfWork.RealEstate.GetlAllIncludeByPriceRange(min,max);
        }

        public List<RealEstate> GetlAllIncludeByTitle(string title)
        {
            return _unitOfWork.RealEstate.GetlAllIncludeByTitle(title);
        }
    }
}
