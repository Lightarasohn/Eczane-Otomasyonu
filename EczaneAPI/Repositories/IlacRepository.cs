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
            _logger.LogInformation("CreateIlacAsync methodu baslatildi");
            var ilac = dto.ToModel();
            var createdİlac = await _context.Ilacs.AddAsync(ilac) ?? throw new Exception("Ilac Veri Tabanina Eklenemedi");
            _logger.LogInformation("Ilac veri tabanina eklendi");
            await _context.SaveChangesAsync();
            _logger.LogInformation("Veri tabani kaydedildi");
            _logger.LogInformation("CreateIlacAsync methodu sona geldi");
            return createdİlac.Entity;
        }

        public async Task<IlacDto> DeleteIlacAsync(int id)
        {
            _logger.LogInformation("DeleteIlacAsync methodu baslatildi");
            var ilac = await _context.Ilacs.FirstOrDefaultAsync(i => i.Id == id) ?? throw new Exception("Ilac alinamadi");
            _logger.LogInformation("Ilac alindi");
            _context.Ilacs.Remove(ilac);
            _logger.LogInformation("Ilac silindi");
            await _context.SaveChangesAsync();
            _logger.LogInformation("Veri tabani kaydedildi");
            _logger.LogInformation("DeleteIlacAsync methodu sona geldi");
            return ilac.ToDto();
        }

        public async Task<List<IlacDto>> GetAllIlacAsync()
        {
            _logger.LogInformation("GetAllIlacAsync methodu baslatildi");
            var ilaclar = await _context.Ilacs.ToListAsync();
            _logger.LogInformation("Ilaclar alindi");
            _logger.LogInformation("GetAllIlacAsync methodu sona geldi");
            return ilaclar.ToDtoList();
        }

        public async Task<IlacDto> GetIlacByIdAsync(int id)
        {
            _logger.LogInformation("GetIlacByIdAsync methodu baslatildi");
            var ilac = await _context.Ilacs.FirstOrDefaultAsync(i => i.Id == id) ?? throw new Exception("Ilac alinamadi");
            _logger.LogInformation("Ilac alindi");
            _logger.LogInformation("GetIlacByIdAsync methodu sona geldi");
            return ilac.ToDto();
        }

        public async Task<IlacDto> UpdateIlacAsync(int id, IlacUpdateDto dto)
        {
            _logger.LogInformation("UpdateIlacAsync methodu baslatildi");
            var updatingIlac = await _context.Ilacs.FirstOrDefaultAsync(i => i.Id == id) ?? throw new Exception("Ilac alinamadi");
            updatingIlac.Adi = dto.Adi;
            updatingIlac.Fiyati = dto.Fiyati;
            updatingIlac.StokDurumu = dto.StokDurumu;
            _logger.LogInformation("Ilac degistirildi");
            await _context.SaveChangesAsync();
            _logger.LogInformation("Veri tabani kaydedildi");
            _logger.LogInformation("UpdateIlacAsync methodu sona geldi");
            return updatingIlac.ToDto();
        }
    }
}