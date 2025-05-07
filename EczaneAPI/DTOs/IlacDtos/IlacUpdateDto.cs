using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EczaneAPI.DTOs.IlacDtos
{
    public class IlacUpdateDto
    {
        public string Adi { get; set; } = null!;

        public double Fiyati { get; set; }

        public int StokDurumu { get; set; }
    }
}