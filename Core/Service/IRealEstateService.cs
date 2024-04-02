﻿using Core.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IRealEstateService : IService<RealEstate>
    {
        List<RealEstate> GetlAllInclude();
        List<RealEstate> GetlAllIncludeByTitle(string title);
        List<RealEstate> GetlAllIncludeByPriceRange(double min, double max);
        List<RealEstate> GetlAllIncludeByFeatures(List<Features> features);
    }
}
