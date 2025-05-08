using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EczaneAPI.DTOs.SatisDtos
{
    public class SatisDto
    {
        public int Id { get; set; }

        public string AliciEmail { get; set; } = null!;

        public DateTime SatisTarihi { get; set; }
    }
}