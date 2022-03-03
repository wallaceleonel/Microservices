using System;
using System.Collections.Generic;
using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
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
    }
}