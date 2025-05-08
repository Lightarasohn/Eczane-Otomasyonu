using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.SatisDtos;
using EczaneAPI.Models;

namespace EczaneAPI.Interfaces
{
    public interface ISatisRepository
    {
        Task<List<SatisDto>> GetAllSatisAsync();
        Task<SatisDto> GetSatisByIdAsync(int id);
        Task<SatisDto> DeleteSatisByIdAsync(int id);
        Task<Satis> CreateSatisAsync(SatisCreateDto dto);
        Task<SatisDto> UpdateSatisByIdAsync(int id, SatisUpdateDto dto);
    }
}