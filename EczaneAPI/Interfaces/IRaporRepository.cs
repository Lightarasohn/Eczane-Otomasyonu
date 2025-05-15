using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.RaporDtos;
using EczaneAPI.Models;

namespace EczaneAPI.Interfaces
{
    public interface IRaporRepository
    {
        Task<List<RaporDto>> GetRaporlarAsync();
        Task<RaporDto> GetRaporByIdAsync(int id);
        Task<Rapor> CreateRaporAsync(RaporCreateDto dto);
        Task<RaporDto> DeleteRaporById(int id);
    }
}