using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.RaporDetayDtos;
using EczaneAPI.DTOs.RaporDtos;
using EczaneAPI.DTOs.RaporSatisDtos;
using EczaneAPI.Interfaces;
using EczaneAPI.Mappers;
using EczaneAPI.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EczaneAPI.Repositories
{
    public class RaporSatisRepository : IRaporSatisRepository
    {
        private readonly EczaneContext _context;
        private readonly ISatisIlacRepository _satisIlacRepo;
        private readonly ILogger<RaporSatisRepository> _logger;
        public RaporSatisRepository(EczaneContext context,
        ILogger<RaporSatisRepository> logger, ISatisIlacRepository satisIlacRepo)
        {
            _context = context;
            _logger = logger;
            _satisIlacRepo = satisIlacRepo;
        }
        public async Task<RaporSatis> CreateRaporSatisAsync(RaporSatisCreateDto dto)
        {
            _logger.LogWarning("CreateRaporSatisAsync methodu baslatildi");
            var rapor = await _context.Raporlar.FirstOrDefaultAsync(x => x.Id == dto.RaporId)
                ?? throw new Exception($"{dto.RaporId} Numaralı Eklenecek Rapor Bulunamadı");
            var satis = await _context.Satislar.FirstOrDefaultAsync(x => x.Id == dto.SatisId)
                ?? throw new Exception($"{dto.RaporId} Numaralı Eklenecek Satis Bulunamadı");
            var satisDetay = await _satisIlacRepo.GetSatisIlacBySatisIdAsync(satis.Id);
            var raporSatis = dto.ToModel();
            raporSatis.Rapor = rapor;
            raporSatis.Satis = satis;
            raporSatis.ToplamTutar = satisDetay.ToplamTutar;
            var createdRaporSatis = await _context.RaporSatislar.AddAsync(raporSatis);
            await _context.SaveChangesAsync();

            return createdRaporSatis.Entity;
        }

        public async Task<RaporDetayDto> GetRaporDetayByRaporIdAsync(int raporId)
{
    var rapor = await _context.Raporlar.FirstOrDefaultAsync(x => x.Id == raporId)
        ?? throw new Exception("Böyle bir rapor yok");

    var raporSatislar = await _context.RaporSatislar
        .Include(x => x.Rapor)
        .Include(x => x.Satis)
        .Where(x => x.RaporId == raporId)
        .ToListAsync();

    // PARALEL DEĞİL, SIRALI İŞLEME
    var raporSatislarDetayDto = new List<RaporDetaySatisDto>();

    foreach (var x in raporSatislar)
    {
        var satisDetay = await _satisIlacRepo.GetSatisIlacBySatisIdAsync(x.SatisId);

        raporSatislarDetayDto.Add(new RaporDetaySatisDto
        {
            Satis = x.Satis.ToDto(),
            SatisId = x.SatisId,
            SatisDetay = satisDetay
        });
    }

    float raporToplamTutar = (float)raporSatislarDetayDto.Sum(x => x.SatisDetay.ToplamTutar);

    var raporDetay = new RaporDetayDto
    {
        Rapor = rapor.ToDto(),
        RaporDetaylar = raporSatislarDetayDto,
        ToplamRaporTutari = raporToplamTutar
    };

    return raporDetay;
}


        public async Task<RaporSatisDto> GetRaporSatislarByIdAsync(int raporId, int satisId)
        {
            var rapor = await _context.Raporlar.FirstOrDefaultAsync(x => x.Id == raporId)
                ?? throw new Exception("İlişkisel Rapor Bulunamadi");
            var satis = await _context.Raporlar.FirstOrDefaultAsync(x => x.Id == satisId)
                ?? throw new Exception("İlişkisel Satış Bulunamadi");
            var raporSatis = await _context.RaporSatislar.Include(x => x.Rapor)
            .Include(x => x.Satis).FirstOrDefaultAsync(x => x.RaporId == raporId && x.SatisId == satisId)
                ?? throw new Exception("Böyle bir rapor-satis ilişkisi yok");

            return raporSatis.ToDto();
        }
        
    }
}