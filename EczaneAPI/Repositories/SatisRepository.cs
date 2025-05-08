using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.SatisDtos;
using EczaneAPI.Interfaces;
using EczaneAPI.Mappers;
using EczaneAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EczaneAPI.Repositories
{
    public class SatisRepository : ISatisRepository
    {
        private readonly EczaneContext _context;
        private readonly ILogger<SatisRepository> _logger;
        public SatisRepository(EczaneContext context, ILogger<SatisRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Satis> CreateSatisAsync(SatisCreateDto dto)
        {
            _logger.LogWarning("CreateSatisAsync methodu baslatildi");
            var satis = dto.ToModel();
            var createdSatis = await _context.Satislar.AddAsync(satis);
            _logger.LogInformation("Satis eklendi");
            await _context.SaveChangesAsync();
            _logger.LogInformation("Veri tabani kaydedildi");
            _logger.LogWarning("GetAllSatisAsync methodu sona geldi");
            return createdSatis.Entity;
        }

        public async Task<SatisDto> DeleteSatisByIdAsync(int id)
        {
            _logger.LogWarning("DeleteSatisByIdAsync methodu baslatildi");
            var satis = await _context.Satislar.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Satis alinamadi");
            _logger.LogInformation("Satis alindi");
            _context.Satislar.Remove(satis);
            _logger.LogInformation("Satis kaldirildi");
            await _context.SaveChangesAsync();
            _logger.LogInformation("Veri tabani kaydedildi");
            _logger.LogWarning("GetAllSatisAsync methodu sona geldi");
            return satis.ToDto();
        }

        public async Task<List<SatisDto>> GetAllSatisAsync()
        {
            _logger.LogWarning("GetAllSatisAsync methodu baslatildi");
            var satislar = await _context.Satislar.ToListAsync();
            _logger.LogInformation("Satislar alindi");
            _logger.LogWarning("GetAllSatisAsync methodu sona geldi");
            return satislar.ToDtoList();
        }

        public async Task<SatisDto> GetSatisByIdAsync(int id)
        {
            _logger.LogWarning("GetSatisByIdAsync methodu baslatildi");
            var satis = await _context.Satislar.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Satis alinamadi");
            _logger.LogInformation("Satis alindi");
            _logger.LogWarning("GetAllSatisAsync methodu sona geldi");
            return satis.ToDto();
        }

        public async Task<SatisDto> UpdateSatisByIdAsync(int id, SatisUpdateDto dto)
        {
            _logger.LogWarning("UpdateSatisByIdAsync methodu baslatildi");
            var satis = await _context.Satislar.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Satis alinamadi");
            _logger.LogInformation("Satis alindi");
            satis.AliciEmail = dto.AliciEmail;
            satis.SatisTarihi = dto.SatisTarihi;
            _logger.LogInformation("Satis degistirildi");
            await _context.SaveChangesAsync();
            _logger.LogInformation("Veri tabani kaydedildi");
            _logger.LogWarning("GetAllSatisAsync methodu sona geldi");
            return satis.ToDto();
        }
    }
}