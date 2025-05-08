using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.SatisIlacDtos;
using EczaneAPI.Models;

namespace EczaneAPI.Interfaces
{
    public interface ISatisIlacRepository
    {
        Task<List<SatisIlacDto>> GetAllSatisIlacAsync();
        Task<SatisIlacDto> GetSatisIlacByIdAsync(int IlacId, int SatisId);
        Task<SatisIlacDto> DeleteSatisIlacByIdAsync(int IlacId, int SatisId);
        Task<SatisIlac> CreateSatisIlacAsync(SatisIlacCreateDto dto);
        Task<SatisIlacDto> UpdateSatisIlacByIdAsync(int IlacId, int SatisId, SatisIlacUpdateDto dto);
    }
}