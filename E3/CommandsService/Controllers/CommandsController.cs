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
        private object platformId;

        public CommandsController(ICommandRepo repository , IMapper mapper )
        {
             _repository = repository;
             _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetCommandsForPlatform(int PlatformId)
        {
            Console.WriteLine($"--> Hit GetCommandsForPlatforms :{platformId}");

            if (!_repository.PlatformExists(PlatformId))
            {
                return NotFound();
            }
            var commands = _repository.GetCommandsForPlatform(PlatformId);
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }
        
    }
}