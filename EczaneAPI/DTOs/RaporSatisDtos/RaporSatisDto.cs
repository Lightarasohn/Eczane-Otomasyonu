using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.Models;

namespace EczaneAPI.DTOs.RaporSatisDtos
{
    public class RaporSatisDto
    {
        public int RaporId { get; set; }

        public int SatisId { get; set; }

        public double ToplamTutar { get; set; }

        public virtual Rapor Rapor { get; set; } = null!;

        public virtual Satis Satis { get; set; } = null!;
    }
}