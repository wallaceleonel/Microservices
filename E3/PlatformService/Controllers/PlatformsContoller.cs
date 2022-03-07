using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.AsynDataServices;
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
        private readonly IMessageBusClient _messageBusClient;

        public PlatformsController(
            IPlatformRepo repository,
             IMapper mapper,
             ICommandDataClient commandDataClient,
             IMessageBusClient MessageBusClient) 
        {
            _repository = repository;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
            _messageBusClient = MessageBusClient;           
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

                // Send Sync Message 
                try
                {
                    await _commandDataClient.SendPlatformToCommand(PlatformReadDto);      
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"--> Could not send synchrously: {ex.Message}");
                }

                // Send Async Message 
                try
                {
                  var PlatformPublishedDto = _mapper.Map<PlatformPublishedDto>(PlatformReadDto);
                  PlatformPublishedDto.Event = "Platform_Published";
                  _messageBusClient.PublishNewPlatform(PlatformPublishedDto);
                }
                catch(Exception ex)
                {
                    Console.WriteLine($" --> Could not send synchronously : {ex.Message}");
                }
                return CreatedAtRoute(nameof(GetPlatformById), new { Id = PlatformReadDto.Id}, PlatformReadDto);
        }
    }     
}