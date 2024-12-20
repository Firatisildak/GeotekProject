﻿using GeotekProject.Application.DTOs.Bosaltma;
using GeotekProject.Application.DTOs.Kantar;
using GeotekProject.Application.Interfaces;
using GeotekProject.Domain.Entities;
using GeotekProject.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeotekProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KantarsController(IKantarRepository kantarRepository) : ControllerBase
    {
        private readonly IKantarRepository _kantarRepository = kantarRepository;

        [HttpGet("[action]")]
        public Task<IActionResult> GetAllKantar() => Task.FromResult<IActionResult>(Ok(_kantarRepository.GetAll()));

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdKantar(string id) => Ok(await _kantarRepository.GetById(id));

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllKantarlarWithKamyon() => Ok(await _kantarRepository.GetAllWithKamyonAsync());

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateKantar(CreateKantar createKantar)
        {
            Kantar kantar = new()
            {
                KamyonId = createKantar.KamyonId,
                KamyonKg = createKantar.KamyonKg,
                OnayDurum = createKantar.OnayDurum,
                Plaka = createKantar.Plaka 
            };
            await _kantarRepository.AddAsync(kantar);
            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateKantar(UpdateKantar updateKantar)
        {
            Kantar kantar = new()
            {
                Id = updateKantar.Id,
                KamyonId = updateKantar.KamyonId,
                KamyonKg = updateKantar.KamyonKg,
                OnayDurum = updateKantar.OnayDurum,
                Plaka = updateKantar.Plaka  
            };
            await _kantarRepository.Update(kantar);
            return Ok();
        }

        [HttpDelete("[action]")]
        public async Task<bool> RemoveKantar(string id) => await _kantarRepository.RemoveAsync(id);

        [HttpGet("[action]")]
        public async Task<IActionResult> GetKantarById(string kantarId) => Ok(await _kantarRepository.GetById(kantarId));
    }
}
