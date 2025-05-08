using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.SatisIlacDtos;
using EczaneAPI.Models;

namespace EczaneAPI.Mappers
{
    public static class SatisIlacMappers
    {
        public static SatisIlacDto ToDto(this SatisIlac model)
        {
            return new SatisIlacDto
            {
                IlacId = model.IlacId,
                Ilac = model.Ilac,
                Satis = model.Satis,
                SatisId = model.SatisId,
                Miktar = model.Miktar
            };
        }
        public static List<SatisIlacDto> ToDtoList(this List<SatisIlac> list)
        {
            return list.Select(x => x.ToDto()).ToList();
        }
        public static SatisIlac ToModel(this SatisIlacCreateDto dto)
        {
            return new SatisIlac
            {
                IlacId = dto.IlacId,
                Miktar = dto.Miktar,
                SatisId = dto.SatisId
            };
        }
    }
}