using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.SatisDtos;
using EczaneAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EczaneAPI.Controllers
{
    [ApiController]
    [Route("api/satis")]
    public class SatisController : ControllerBase
    {
        private readonly ISatisRepository _satisRepo;
        public SatisController(ISatisRepository satisRepo)
        {
            _satisRepo = satisRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var satislar = await _satisRepo.GetAllSatisAsync();

                return Ok(satislar);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var satis = await _satisRepo.GetSatisByIdAsync(id);
                return Ok(satis);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute]int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var satis = await _satisRepo.DeleteSatisByIdAsync(id);
                return Ok(satis);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{satisId}")]
        public async Task<IActionResult> Put([FromRoute]int satisId, [FromBody]SatisUpdateDto dto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var satis = await _satisRepo.UpdateSatisByIdAsync(satisId, dto);
                return Ok(satis);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SatisCreateDto dto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var satis = await _satisRepo.CreateSatisAsync(dto);
                return CreatedAtAction(nameof(GetById), new { Id = satis.Id}, satis);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}