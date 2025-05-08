using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.SatisDetayDtos;
using EczaneAPI.Models;

namespace EczaneAPI.Mappers
{
    public static class SatisDetayMappers
    {
        public static SatisDetayIlacDto ToSatisDetayIlacDto(this SatisIlac satisIlac)
        {
            return new SatisDetayIlacDto
            {
                IlacId = satisIlac.IlacId,
                Ilac = satisIlac.Ilac.ToDto(),
                Miktar = satisIlac.Miktar,
            };
        }

        public static List<SatisDetayIlacDto> ToDetayDtoList(this List<SatisIlac> satisIlaclar)
        {
            return satisIlaclar.Select(s => s.ToSatisDetayIlacDto()).ToList();
        }
    }
}