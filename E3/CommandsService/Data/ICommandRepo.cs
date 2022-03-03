using System.Collections.Generic;
using CommandService.models;
using CommandsService.Models;

namespace CommandsService.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();

        //Platform
        IEnumerable<platform> GetAllPlatforms();
        void CreatePlatform(platform plat);
        bool PlatformExists(int PlatformId);
        
        //Commands
        IEnumerable<Command> GetCommandsForPlatform(int PlatformId);
        Command GetCommand(int platformId, int commandId);
        void CreateCommand(int platformId,  Command command);
    }

}