using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EczaneAPI.DTOs.RaporDtos
{
    public class RaporDto
    {
        public int Id { get; set; }

        public DateOnly BaslangicTarihi { get; set; }

        public DateOnly BitisTarihi { get; set; }

    }
}