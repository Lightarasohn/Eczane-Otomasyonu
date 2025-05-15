using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.RaporDtos;
using EczaneAPI.Models;

namespace EczaneAPI.DTOs.RaporDetayDtos
{
    public class RaporDetayDto
    {
        public List<RaporDetaySatisDto> RaporDetaylar { get; set; } = new List<RaporDetaySatisDto>();
        public float ToplamRaporTutari { get; set; }
        public RaporDto Rapor { get; set; } = new RaporDto();
    }
}