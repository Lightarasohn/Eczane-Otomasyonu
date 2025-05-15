using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.RaporDtos;
using EczaneAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EczaneAPI.Controllers
{
    [ApiController]
    [Route("api/rapor")]
    public class RaporController : ControllerBase
    {
        private readonly IRaporRepository _raporRepo;
        public RaporController(IRaporRepository raporRepo)
        {
            _raporRepo = raporRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var raporlar = await _raporRepo.GetRaporlarAsync();
                return Ok(raporlar);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var rapor = await _raporRepo.GetRaporByIdAsync(id);
                return Ok(rapor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var rapor = await _raporRepo.DeleteRaporById(id);
                return Ok(rapor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RaporCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var createdRapor = await _raporRepo.CreateRaporAsync(dto);
                return CreatedAtAction(nameof(GetById), new { Id = createdRapor.Id }, createdRapor);    
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}