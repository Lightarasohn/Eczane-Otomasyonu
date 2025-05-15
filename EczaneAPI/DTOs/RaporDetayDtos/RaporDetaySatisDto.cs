using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.SatisDetayDtos;
using EczaneAPI.DTOs.SatisDtos;
using EczaneAPI.Models;

namespace EczaneAPI.DTOs.RaporDetayDtos
{
    public class RaporDetaySatisDto
    {
        public int SatisId { get; set; }
        public SatisDto Satis { get; set; } = new SatisDto()!;
        public SatisDetayDto SatisDetay { get; set; } = new SatisDetayDto();
    }
}