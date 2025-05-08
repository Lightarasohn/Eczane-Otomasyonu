using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.SatisIlacDtos;
using EczaneAPI.Interfaces;
using EczaneAPI.Mappers;
using EczaneAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EczaneAPI.Repositories
{
    public class SatisIlacRepository : ISatisIlacRepository
    {
        private readonly EczaneContext _context;
        private readonly ILogger<SatisIlacRepository> _logger;

        public SatisIlacRepository(EczaneContext context, ILogger<SatisIlacRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<SatisIlac> CreateSatisIlacAsync(SatisIlacCreateDto dto)
        {
            _logger.LogWarning("CreateSatisIlacAsync methodu baslatildi");
            var satisIlac = dto.ToModel();
            var createdSatisIlac = await _context.SatisIlacs.AddAsync(satisIlac);
            _logger.LogInformation("SatisIlac eklendi");
            await _context.SaveChangesAsync();
            _logger.LogInformation("Veri tabani kaydedildi");
            _logger.LogWarning("CreateSatisIlacAsync methodu sona erdi");
            return createdSatisIlac.Entity;
        }

        public async Task<SatisIlacDto> DeleteSatisIlacByIdAsync(int satisId, int ilacId)
        {
            _logger.LogWarning("DeleteSatisIlacByIdAsync methodu baslatildi");
            var satisIlac = await _context.SatisIlacs
                .FirstOrDefaultAsync(x => x.SatisId == satisId && x.IlacId == ilacId) 
                ?? throw new Exception("SatisIlac bulunamadi");
            _logger.LogInformation("SatisIlac alindi");
            _context.SatisIlacs.Remove(satisIlac);
            _logger.LogInformation("SatisIlac kaldirildi");
            await _context.SaveChangesAsync();
            _logger.LogInformation("Veri tabani kaydedildi");
            _logger.LogWarning("DeleteSatisIlacByIdAsync methodu sona erdi");
            return satisIlac.ToDto();
        }

        public async Task<List<SatisIlacDto>> GetAllSatisIlacAsync()
        {
            _logger.LogWarning("GetAllSatisIlacAsync methodu baslatildi");
            var satisIlaclar = await _context.SatisIlacs
                .Include(x => x.Ilac)
                .Include(x => x.Satis)
                .ToListAsync();
            _logger.LogInformation("SatisIlac alindi");
            _logger.LogWarning("GetAllSatisIlacAsync methodu sona erdi");
            return satisIlaclar.ToDtoList();
        }

        public async Task<SatisIlacDto> GetSatisIlacByIdAsync(int satisId, int ilacId)
        {
            _logger.LogWarning("GetSatisIlacByIdAsync methodu baslatildi");
            var satisIlac = await _context.SatisIlacs
                .Include(x => x.Ilac)
                .Include(x => x.Satis)
                .FirstOrDefaultAsync(x => x.SatisId == satisId && x.IlacId == ilacId) 
                ?? throw new Exception("SatisIlac bulunamadi");
            _logger.LogInformation("SatisIlac alindi");
            _logger.LogWarning("GetSatisIlacByIdAsync methodu sona erdi");
            return satisIlac.ToDto();
        }

        public async Task<SatisIlacDto> UpdateSatisIlacByIdAsync(int satisId, int ilacId, SatisIlacUpdateDto dto)
        {
            _logger.LogWarning("UpdateSatisIlacByIdAsync methodu baslatildi");
            var satisIlac = await _context.SatisIlacs
                .FirstOrDefaultAsync(x => x.SatisId == satisId && x.IlacId == ilacId) 
                ?? throw new Exception("SatisIlac bulunamadi");
            _logger.LogInformation("SatisIlac alindi");
            satisIlac.Miktar = dto.Miktar;
            _logger.LogInformation("SatisIlac guncellendi");
            await _context.SaveChangesAsync();
            _logger.LogInformation("Veri tabani kaydedildi");
            _logger.LogWarning("UpdateSatisIlacByIdAsync methodu sona erdi");
            return satisIlac.ToDto();
        }
    }
}