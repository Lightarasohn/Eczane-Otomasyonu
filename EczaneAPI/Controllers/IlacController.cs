using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EczaneAPI.DTOs.IlacDtos;
using EczaneAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EczaneAPI.Controllers
{
    [ApiController]
    [Route("api/ilac")]
    public class IlacController : ControllerBase
    {
        private readonly IIlacRepository _ilacRepo;
        public IlacController(IIlacRepository ilacRepo)
        {
            _ilacRepo = ilacRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var ilaclar = await _ilacRepo.GetAllIlacAsync();
                return Ok(ilaclar);
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
                var ilac = await _ilacRepo.GetIlacByIdAsync(id);
                return Ok(ilac);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var ilac = await _ilacRepo.DeleteIlacAsync(id);
                return Ok(ilac);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]IlacCreateDto dto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var ilac = await _ilacRepo.CreateIlacAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = ilac.Id }, ilac);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody]IlacUpdateDto dto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var ilac = await _ilacRepo.UpdateIlacAsync(id, dto);
                return Ok(ilac);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}