using CommandService.models;

namespace CommandService.Models
{
    public class Command
    {
        public int Id { get; set; }

        public string Howto  { get; set; }

        public string CommandLine  { get; set; }

        public int PlatformId { get; set; }

        public platform platform {get ; set;}
    }
}