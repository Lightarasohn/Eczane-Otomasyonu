using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.RaporSatisDtos;
using EczaneAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EczaneAPI.Controllers
{
    [ApiController]
    [Route("api/rapor-satis")]
    public class RaporSatisController : ControllerBase
    {
        private readonly IRaporSatisRepository _raporSatisRepo;
        public RaporSatisController(IRaporSatisRepository raporSatisRepo)
        {
            _raporSatisRepo = raporSatisRepo;
        }

        [HttpGet("{raporID}/{satisId}")]
        public async Task<IActionResult> GetById([FromRoute] int raporID, [FromRoute] int satisId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var raporSatislar = await _raporSatisRepo.GetRaporSatislarByIdAsync(raporId: raporID, satisId: satisId);

                return Ok(raporSatislar);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{raporId}")]
        public async Task<IActionResult> GetByRaporId([FromRoute] int raporId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var raporDetay = await _raporSatisRepo.GetRaporDetayByRaporIdAsync(raporId);

                return Ok(raporDetay);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RaporSatisCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var raporSatis = await _raporSatisRepo.CreateRaporSatisAsync(dto);

                return Ok(raporSatis);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}