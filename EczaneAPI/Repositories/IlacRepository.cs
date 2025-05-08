using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.IlacDtos;
using EczaneAPI.Interfaces;
using EczaneAPI.Mappers;
using EczaneAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EczaneAPI.Repositories
{
    public class IlacRepository : IIlacRepository
    {
        private readonly EczaneContext _context;
        private readonly ILogger<IlacRepository> _logger;
        public IlacRepository(EczaneContext context, ILogger<IlacRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Ilac> CreateIlacAsync(IlacCreateDto dto)
        {
            _logger.LogWarning("CreateIlacAsync methodu baslatildi");
            var existingIlac = await _context.Ilaclar.FirstOrDefaultAsync(i => i.Adi == dto.Adi);
            if (existingIlac != null)
            {
                _logger.LogWarning("Bu isimde bir ilac zaten var");
                throw new Exception("Bu isimde bir ilac zaten var");
            }
            var ilac = dto.ToModel();
            var createdİlac = await _context.Ilaclar.AddAsync(ilac) ?? throw new Exception("Ilac Veri Tabanina Eklenemedi");
            _logger.LogInformation("Ilac veri tabanina eklendi");
            await _context.SaveChangesAsync();
            _logger.LogInformation("Veri tabani kaydedildi");
            _logger.LogWarning("CreateIlacAsync methodu sona geldi");
            return createdİlac.Entity;
        }

        public async Task<IlacDto> DeleteIlacAsync(int id)
        {
            _logger.LogWarning("DeleteIlacAsync methodu baslatildi");
            var ilac = await _context.Ilaclar.FirstOrDefaultAsync(i => i.Id == id) ?? throw new Exception("Ilac bulunamadi");
            _logger.LogInformation("Ilac alindi");
            _context.Ilaclar.Remove(ilac);
            _logger.LogInformation("Ilac silindi");
            await _context.SaveChangesAsync();
            _logger.LogInformation("Veri tabani kaydedildi");
            _logger.LogWarning("DeleteIlacAsync methodu sona geldi");
            return ilac.ToDto();
        }

        public async Task<List<IlacDto>> GetAllIlacAsync()
        {
            _logger.LogWarning("GetAllIlacAsync methodu baslatildi");
            var ilaclar = await _context.Ilaclar.ToListAsync();
            _logger.LogInformation("Ilaclar alindi");
            _logger.LogWarning("GetAllIlacAsync methodu sona geldi");
            return ilaclar.ToDtoList();
        }

        public async Task<IlacDto> GetIlacByIdAsync(int id)
        {
            _logger.LogWarning("GetIlacByIdAsync methodu baslatildi");
            var ilac = await _context.Ilaclar.FirstOrDefaultAsync(i => i.Id == id) ?? throw new Exception("Ilac bulunamadi");
            _logger.LogInformation("Ilac alindi");
            _logger.LogWarning("GetIlacByIdAsync methodu sona geldi");
            return ilac.ToDto();
        }

        public async Task<IlacDto> UpdateIlacAsync(int id, IlacUpdateDto dto)
        {
            _logger.LogWarning("UpdateIlacAsync methodu baslatildi");
            var updatingIlac = await _context.Ilaclar.FirstOrDefaultAsync(i => i.Id == id) ?? throw new Exception("Ilac bulunamadi");
            updatingIlac.Adi = dto.Adi;
            updatingIlac.Fiyati = dto.Fiyati;
            updatingIlac.StokDurumu = dto.StokDurumu;
            _logger.LogInformation("Ilac degistirildi");
            await _context.SaveChangesAsync();
            _logger.LogInformation("Veri tabani kaydedildi");
            _logger.LogWarning("UpdateIlacAsync methodu sona geldi");
            return updatingIlac.ToDto();
        }
    }
}