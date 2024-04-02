using AutoMapper;
using Core.DTOs;
using Core.Model;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;

namespace api.Controllers
{
    [Route("api")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRealEstateService _reService;
        private readonly IService<Features> _feService;

        public RealEstateController(IRealEstateService reService, IMapper mapper, IService<Features> feService)
        {
            _reService = reService;
            _mapper = mapper;
            _feService = feService;
        }

        [Route("RealEstate")]
        [HttpGet]
        public IActionResult RealEstate() {
            var realestate = _reService.GetlAllInclude();

            var realestateDtos = _mapper.Map<List<RealEstateDto>>(realestate);

            return Ok(ResponseDto<List<RealEstateDto>>.Success(200, realestateDtos));
        
        }

        [Route("RealEstateByTitle")]
        [HttpPost]
        public IActionResult RealEstateByTitle(string title)
        {
            List<RealEstate> realestate = new();

            if (!string.IsNullOrEmpty(title)) {

                realestate = _reService.GetlAllIncludeByTitle(title);

            }
            else
            {
                realestate = _reService.GetlAllInclude();
            }

            var realestateDtos = _mapper.Map<List<RealEstateDto>>(realestate);

            return Ok(ResponseDto<List<RealEstateDto>>.Success(200, realestateDtos));

        }
        [Route("RealEstateRangePrice")]
        [HttpPost]
        public IActionResult RealEstateRangePrice(double min, double max)
        {
            List<RealEstate> realestate = _reService.GetlAllIncludeByPriceRange(min, max);

            var realestateDtos = _mapper.Map<List<RealEstateDto>>(realestate);

            return Ok(ResponseDto<List<RealEstateDto>>.Success(200, realestateDtos));

        }

        [Route("GetAllFeatures")]
        [HttpPost]
        public IActionResult GetAllFeatures()
        {
            var features = _feService.GetAll();

            return Ok(features);

        }

        [Route("GetEstateByFeatures")]
        [HttpPost]
        public async Task<IActionResult> GetEstateByFeatures(string value)
        {
            string[] nVal = value.Split(',');

            List<Features> LF = new();

            for (int i = 0; i < nVal.Length; i++) { 
            
                var feature = await _feService.FirstOfDefaultAsync(x => x.Id == Convert.ToInt32(nVal[i]));

                LF.Add(feature);

            }

            var realestate = _reService.GetlAllIncludeByFeatures(LF);

            var realestateDtos = _mapper.Map<List<RealEstateDto>>(realestate);

            return Ok(ResponseDto<List<RealEstateDto>>.Success(200, realestateDtos));

        }
    }
}
