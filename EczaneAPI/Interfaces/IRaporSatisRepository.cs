using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.RaporDetayDtos;
using EczaneAPI.DTOs.RaporDtos;
using EczaneAPI.DTOs.RaporSatisDtos;
using EczaneAPI.Models;

namespace EczaneAPI.Interfaces
{
    public interface IRaporSatisRepository
    {
        Task<RaporSatis> CreateRaporSatisAsync(RaporSatisCreateDto dto);
        Task<RaporSatisDto> GetRaporSatislarByIdAsync(int raporId, int satisId);
        Task<RaporDetayDto> GetRaporDetayByRaporIdAsync(int raporId);
    }
}