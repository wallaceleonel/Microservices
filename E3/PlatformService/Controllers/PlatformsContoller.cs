using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public PlatformsController(
            IPlatformRepo repository,
             IMapper mapper,
             ICommandDataClient commandDataClient) 
        {
            _repository = repository;
            _mapper = mapper;
            _commandDataClient = commandDataClient;           
        }
          [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms .... ");

            var PlatformItem = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(PlatformItem));
        }
        [HttpGet("{id}", Name ="GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            var PlatformItem = _repository.GetPlatformById(id);
            if(PlatformItem != null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(PlatformItem));
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<PlatformReadDto>> CreatPlatform(PlatformCreateDto platformCreateDto)
        {
                var PlatformModel = _mapper.Map<Platform>(platformCreateDto);
                _repository.CreatePlatform(PlatformModel);
                _repository.SaveChanges();

                var PlatformReadDto = _mapper.Map<PlatformReadDto>(PlatformModel);

                try
                {
                    await _commandDataClient.SendPlatformToCommand(PlatformReadDto);      
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"--> Could not send synchrously: {ex.Message}");
                }

                return CreatedAtRoute(nameof(GetPlatformById), new { Id = PlatformReadDto.Id}, PlatformReadDto);
        }
    }     
}