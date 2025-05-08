using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.SatisIlacDtos;
using EczaneAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EczaneAPI.Controllers
{
    [ApiController]
    [Route("api/satis-ilac")]
    public class SatisIlacController : ControllerBase
    {
        private readonly ISatisIlacRepository _satisIlacRepo;
        public SatisIlacController(ISatisIlacRepository satisIlacRepo)
        {
            _satisIlacRepo = satisIlacRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var satisIlaclar = await _satisIlacRepo.GetAllSatisIlacAsync();
                return Ok(satisIlaclar);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{satisId}/{ilacId}")]
        public async Task<IActionResult> GetById([FromRoute]int satisId, [FromRoute]int ilacId)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var satisIlac = await _satisIlacRepo.GetSatisIlacByIdAsync(SatisId:satisId, IlacId:ilacId);
                return Ok(satisIlac);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{satisId}")]
        public async Task<IActionResult> GetBySatisId([FromRoute]int satisId)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var satisIlaclar = await _satisIlacRepo.GetSatisIlacBySatisIdAsync(SatisId:satisId);
                return Ok(satisIlaclar);

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{satisId}/{ilacId}")]
        public async Task<IActionResult> DeleteById([FromRoute]int satisId, [FromRoute]int ilacId)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var satisIlac = await _satisIlacRepo.DeleteSatisIlacByIdAsync(SatisId:satisId, IlacId:ilacId);
                return Ok(satisIlac);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SatisIlacCreateDto dto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var satisIlac = await _satisIlacRepo.CreateSatisIlacAsync(dto);
                return CreatedAtAction(nameof(GetById), new {satisId = satisIlac.SatisId, ilacId = satisIlac.IlacId}, satisIlac);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]SatisIlacUpdateDto dto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var satisIlac = await _satisIlacRepo.UpdateSatisIlacByIdAsync(dto:dto);
                return Ok(satisIlac);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}