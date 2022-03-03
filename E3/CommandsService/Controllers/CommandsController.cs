using System;
using System.Collections.Generic;
using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using CommandsService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/c/platforms/{platdormId}/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private ICommandRepo _repository;
        private IMapper _mapper;
        public CommandsController(ICommandRepo repository , IMapper mapper )
        {
             _repository = repository;
             _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetCommandsForPlatform(int PlatformId)
        {
            Console.WriteLine($"--> Hit GetCommandsForPlatforms :{PlatformId}");

            if (!_repository.PlatformExists(PlatformId))
            {
                return NotFound();
            }
            var commands = _repository.GetCommandsForPlatform(PlatformId);
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }
         [HttpGet("{commandId}", Name  ="GetCommandForPlatform")]
         public ActionResult<CommandReadDto> GetCommandForPlatform(int platformId, int commandId)
         {
               Console.WriteLine($"--> Hit GetCommandsForPlatforms :{platformId} / {commandId}");

            if (!_repository.PlatformExists(platformId))
            {
                return NotFound();
            }
            var command = _repository.GetCommand(platformId,commandId);

            if(command == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CommandReadDto>(command)); 
        }
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommandForPlaform(int platformId,CommandCreateDto commandDto)
        {
             Console.WriteLine($"--> Hit CreateCommandForPlaform :{platformId}");

            if (!_repository.PlatformExists(platformId))
            {
                return NotFound();
            }

            var command = _mapper.Map<Command>(commandDto);

            _repository.CreateCommand(platformId,command);
            _repository.SaveChanges();

            var CommandreadDto = _mapper.Map<CommandReadDto>(command);

            return CreatedAtRoute(nameof(GetCommandForPlatform),
                new {platformId = platformId, commandId = CommandreadDto.Id},CommandreadDto);
        }
    }
}