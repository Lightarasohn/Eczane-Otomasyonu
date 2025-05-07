using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.IlacDtos;
using EczaneAPI.Models;

namespace EczaneAPI.Interfaces
{
    public interface IIlacRepository
    {
        Task<List<IlacDto>> GetAllIlacAsync();
        Task<IlacDto> GetIlacByIdAsync(int id);
        Task<Ilac> CreateIlacAsync(IlacCreateDto dto);
        Task<IlacDto> DeleteIlacAsync(int id);
        Task<IlacDto> UpdateIlacAsync(int id, IlacUpdateDto dto);
    }
}