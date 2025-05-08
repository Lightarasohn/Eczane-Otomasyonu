using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.IlacDtos;

namespace EczaneAPI.DTOs.SatisDetayDtos
{
    public class SatisDetayIlacDto
    {
        public int IlacId { get; set; }
        public IlacDto Ilac { get; set; } = new IlacDto();
        public int Miktar { get; set; }
    }
}