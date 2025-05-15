using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.RaporDetayDtos;
using EczaneAPI.DTOs.RaporSatisDtos;
using EczaneAPI.Models;

namespace EczaneAPI.Mappers
{
    public static class RaporSatisMappers
    {
        public static RaporSatis ToModel(this RaporSatisCreateDto dto)
        {
            return new RaporSatis
            {
                RaporId = dto.RaporId,
                SatisId = dto.SatisId
            };
        }
        public static RaporSatisDto ToDto(this RaporSatis model)
        {
            return new RaporSatisDto
            {
                RaporId = model.RaporId,
                Rapor = model.Rapor,
                Satis = model.Satis,
                SatisId = model.SatisId,
                ToplamTutar = model.ToplamTutar
            };
        }
    }
}