using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.SatisDetayDtos;
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
        private readonly IIlacRepository _ilacRepository;
        private readonly ILogger<SatisIlacRepository> _logger;

        public SatisIlacRepository(EczaneContext context, ILogger<SatisIlacRepository> logger, IIlacRepository ilacRepository)
        {
            _ilacRepository = ilacRepository;
            _logger = logger;
            _context = context;
        }
        public async Task<SatisIlac> CreateSatisIlacAsync(SatisIlacCreateDto dto)
        {
            _logger.LogWarning("CreateSatisIlacAsync methodu baslatildi");
            var satis = await _context.Satislar.FirstOrDefaultAsync(s => s.Id == dto.SatisId) ?? throw new Exception("Boyle bir satis yok");
            var ilac = await _context.Ilaclar.FirstOrDefaultAsync(i => i.Id == dto.IlacId) ?? throw new Exception("Boyle bir ilac yok");
            
            var existingSatisIlac = await _context.SatisIlacs
                .FirstOrDefaultAsync(x => x.SatisId == dto.SatisId && x.IlacId == dto.IlacId);
            
            if (existingSatisIlac != null)
            {
                _logger.LogWarning("Bu satista bu ilac zaten var");
                throw new Exception("Bu satista bu ilac zaten var");
            }

            if (ilac.StokDurumu < dto.Miktar) throw new Exception("Yeterli miktarda ilac yok"  + "Stok: " + ilac.StokDurumu);
            ilac.StokDurumu -= dto.Miktar;
            await _ilacRepository.UpdateIlacAsync(ilac.Id, ilac.ToUpdateDto());
            
            var satisIlac = dto.ToModel();
            satisIlac.Ilac = ilac;
            satisIlac.Satis = satis;
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

        public async Task<SatisDetayDto> GetSatisIlacBySatisIdAsync(int satisId)
        {
            _logger.LogWarning("GetSatisIlacBySatisIdAsync methodu baslatildi");
            var satis = await _context.Satislar.FirstOrDefaultAsync(s => s.Id == satisId) ?? throw new Exception("Boyle bir satis yok");
            var satisIlaclar = await _context.SatisIlacs
                .Include(x => x.Ilac)
                .Include(x => x.Satis)
                .Where(x => x.SatisId == satisId)
                .ToListAsync();

            var satisIlaclarDto = satisIlaclar.ToDetayDtoList();
            var toplamTutar = satisIlaclarDto.Sum(x => x.Ilac.Fiyati * x.Miktar);
            var satisDetayDto = new SatisDetayDto
            {
                Satis = satis.ToDto(),
                SatisDetaylar = satisIlaclarDto,
                ToplamTutar = toplamTutar
            };

            _logger.LogInformation("SatisIlac alindi");
            _logger.LogWarning("GetSatisIlacBySatisIdAsync methodu sona erdi");
            return satisDetayDto;;
        }

        public async Task<SatisIlacDto> UpdateSatisIlacByIdAsync(SatisIlacUpdateDto dto)
        {
            _logger.LogWarning("UpdateSatisIlacByIdAsync methodu baslatildi");
            var satisIlac = await _context.SatisIlacs.Include(x => x.Satis).Include(x => x.Ilac)
                .FirstOrDefaultAsync(x => x.SatisId == dto.SatisId && x.IlacId == dto.IlacId) 
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