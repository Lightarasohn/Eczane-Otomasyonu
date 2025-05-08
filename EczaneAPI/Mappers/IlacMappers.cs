using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.IlacDtos;
using EczaneAPI.Models;

namespace EczaneAPI.Mappers
{
    public static class IlacMappers
    {
        public static IlacDto ToDto(this Ilac model)
        {
            return new IlacDto
            {
                Id = model.Id,
                Adi = model.Adi,
                StokDurumu = model.StokDurumu,
                Fiyati = model.Fiyati,

            };
        }
        public static List<IlacDto> ToDtoList(this List<Ilac> list)
        {
            return list.Select(I => I.ToDto()).ToList();
        }
        public static Ilac ToModel(this IlacCreateDto dto)
        {
            return new Ilac
            {
                Adi = dto.Adi,
                StokDurumu = dto.StokDurumu,
                Fiyati = dto.Fiyati
            };
        }
        public static IlacUpdateDto ToUpdateDto(this Ilac model)
        {
            return new IlacUpdateDto
            {
                Adi = model.Adi,
                StokDurumu = model.StokDurumu,
                Fiyati = model.Fiyati
            };
        }
    }
}