﻿using GeotekProject.Application.DTOs.Bosaltma;
using GeotekProject.Application.Interfaces;
using GeotekProject.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeotekProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BosaltmasController : ControllerBase
    {
        private readonly IBosaltmaRepository _bosaltmaRepository;
        public BosaltmasController(IBosaltmaRepository bosaltmaRepository)
        {
            _bosaltmaRepository = bosaltmaRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllBosaltma() => Ok(_bosaltmaRepository.GetAll());


        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdBosaltma(string id) => Ok(await _bosaltmaRepository.GetById(id));

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllBosaltmalarWithKamyon() => Ok(await _bosaltmaRepository.GetAllWithKamyonAsync());

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBosaltma(CreateBosaltma createBosaltma)
        {
            var bosaltma = new Bosaltma
            {
                BosaltmaDurumu = createBosaltma.BosaltmaDurumu,
                KamyonId = createBosaltma.KamyonId
            };
            await _bosaltmaRepository.AddAsync(bosaltma);
            return Ok();

        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateBosaltma(UpdateBosaltma updateBosaltma)
        {
            var bosaltma = new Bosaltma
            {
                Id = updateBosaltma.Id,
                BosaltmaDurumu = updateBosaltma.BosaltmaDurumu,
                KamyonId = updateBosaltma.KamyonId,
            };
            await _bosaltmaRepository.Update(bosaltma);
            return Ok();
        }

        [HttpDelete("[action]")]
        public async Task<bool> RemoveBosaltma(string id) => await _bosaltmaRepository.RemoveAsync(id);

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBosaltmaById(string BosaltmaId) => Ok(await _bosaltmaRepository.GetById(BosaltmaId));
    }
}