using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.SatisDtos;
using EczaneAPI.Models;

namespace EczaneAPI.DTOs.SatisDetayDtos
{
    public class SatisDetayDto
    {
        public List<SatisDetayIlacDto> SatisDetaylar { get; set; } = new List<SatisDetayIlacDto>();
        public double ToplamTutar { get; set; }
        public SatisDto Satis { get; set; } = new SatisDto();
    }
}