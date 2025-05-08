using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EczaneAPI.DTOs.SatisIlacDtos
{
    public class SatisIlacCreateDto
    {
        public int SatisId { get; set; }

        public int IlacId { get; set; }

        public int Miktar { get; set; }
    }
}