using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.SatisDtos;
using EczaneAPI.Models;

namespace EczaneAPI.Mappers
{
    public static class SatisMappers
    {
        public static SatisDto ToDto(this Satis model)
        {
            return new SatisDto
            {
                Id = model.Id,
                SatisTarihi = model.SatisTarihi,
                AliciEmail = model.AliciEmail
            };
        }
        public static List<SatisDto> ToDtoList(this List<Satis> list)
        {
            return list.Select(s => s.ToDto()).ToList();
        }
        public static Satis ToModel(this SatisCreateDto dto)
        {
            return new Satis
            {
                AliciEmail = dto.AliciEmail,
                SatisTarihi = dto.SatisTarihi
            };
        }
    }
}