using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.RaporDtos;
using EczaneAPI.Models;

namespace EczaneAPI.Mappers
{
    public static class RaporMappers
    {
        public static RaporDto ToDto(this Rapor model)
        {
            return new RaporDto
            {
                Id = model.Id,
                BaslangicTarihi = model.BaslangicTarihi,
                BitisTarihi = model.BitisTarihi
            };
        }

        public static List<RaporDto> ToDtoList(this List<Rapor> list)
        {
            return list.Select(rapor => rapor.ToDto()).ToList();
        }

        public static Rapor ToModel(this RaporCreateDto dto)
        {
            return new Rapor
            {
                BaslangicTarihi = dto.BaslangicTarihi,
                BitisTarihi = dto.BitisTarihi
            };
        }
    }
}