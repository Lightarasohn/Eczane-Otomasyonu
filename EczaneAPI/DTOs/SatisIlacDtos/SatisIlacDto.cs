using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.Models;

namespace EczaneAPI.DTOs.SatisIlacDtos
{
    public class SatisIlacDto
    {
        public int SatisId { get; set; }

        public int IlacId { get; set; }

        public int Miktar { get; set; }

        public virtual Ilac Ilac { get; set; } = null!;

        public virtual Satis Satis { get; set; } = null!;

    }
}