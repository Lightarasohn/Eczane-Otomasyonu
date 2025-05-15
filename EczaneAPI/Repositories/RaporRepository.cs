using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.RaporDtos;
using EczaneAPI.Interfaces;
using EczaneAPI.Mappers;
using EczaneAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EczaneAPI.Repositories
{
    public class RaporRepository : IRaporRepository
    {
        private readonly EczaneContext _context;
        private readonly ILogger<RaporRepository> _logger;
        public RaporRepository(EczaneContext context, ILogger<RaporRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Rapor> CreateRaporAsync(RaporCreateDto dto)
        {
            _logger.LogWarning("CreateRaporAsync methodu başlatıldı");
            var rapor = dto.ToModel();
            var createdRapor = await _context.Raporlar.AddAsync(rapor);
            _logger.LogInformation("Rapor veri tabanına eklendi");
            await _context.SaveChangesAsync();
            _logger.LogInformation("Veri tabanı kaydedildi");
            _logger.LogWarning("CreateRaporAsync methodu sona geldi");
            return createdRapor.Entity;
        }

        public async Task<RaporDto> DeleteRaporById(int id)
        {
            _logger.LogWarning("DeleteRaporById methodu başlatıldı");
            var rapor = await _context.Raporlar.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception($"{id} Numaralı Rapor Bulunamadi");
            _logger.LogInformation("Rapor alindi");
            _context.Raporlar.Remove(rapor);
            _logger.LogInformation("Rapor silindi");
            await _context.SaveChangesAsync();
            _logger.LogInformation("Veri tabanı kaydedildi");
            _logger.LogWarning("DeleteRaporById methodu sona geldi");
            return rapor.ToDto();
        }

        public async Task<RaporDto> GetRaporByIdAsync(int id)
        {
            _logger.LogWarning("GetRaporByIdAsync methodu başlatıldı");
            var rapor = await _context.Raporlar.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception($"{id} Numaralı Rapor Bulunamadi");
            _logger.LogInformation("Rapor alindi");
            _logger.LogWarning("GetRaporByIdAsync methodu sona geldi");
            return rapor.ToDto();
        }

        public async Task<List<RaporDto>> GetRaporlarAsync()
        {
            _logger.LogWarning("GetRaporlarAsync methodu başlatıldı");
            var raporList = await _context.Raporlar.ToListAsync();
            _logger.LogInformation("Raporlar alindi");
            _logger.LogWarning("GetRaporlarAsync methodu sona geldi");
            return raporList.ToDtoList();
        }
    }
}