using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EczaneAPI.DTOs.RaporDtos
{
    public class RaporCreateDto
    {

        public DateOnly BaslangicTarihi { get; set; }

        public DateOnly BitisTarihi { get; set; }

    }
}