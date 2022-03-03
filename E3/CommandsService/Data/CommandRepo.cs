using System.Collections.Generic;
using System.Linq;
using CommandService.models;
using CommandsService.Models;
using System;
namespace CommandsService.Data
{
    public class CommandRepo : ICommandRepo
    {
        private AppDbContext _context;

        public CommandRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateCommand(int platformId, Command command)
        {
            if ( command == null)
            {
                throw new AccessViolationException(nameof(command));

            }
            
            command.PlatformId = platformId;
            _context.Commands.Add(command);
        }

        public void CreatePlatform(platform plat)
        {
            if (plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }
            _context.Platforms.Add(plat);
        }

        public IEnumerable<platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Command GetCommand(int platformId, int commandId)
        {
            return _context.Commands
                .Where(c => c.PlatformId == platformId && c.Id == commandId).FirstOrDefault();
        }

        public IEnumerable<Command> GetCommandsForPlatform(int PlatformId)
        {
            return _context.Commands
                .Where(c => c.PlatformId == PlatformId)
                .OrderBy(c => c.platform.Name);
        }

        public bool PlatformExists(int PlatformId)
        {
            return _context.Platforms.Any(p => p.Id == PlatformId);
        }

        public bool PlatformExists(object platformId)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);  
        }
    }
}