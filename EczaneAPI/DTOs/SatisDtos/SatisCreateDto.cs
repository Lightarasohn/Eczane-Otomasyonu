using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EczaneAPI.DTOs.SatisDtos
{
    public class SatisCreateDto
    {
        public string AliciEmail { get; set; } = null!;

        public DateTime SatisTarihi { get; set; }
    }
}