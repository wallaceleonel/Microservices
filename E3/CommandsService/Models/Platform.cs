using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CommandsService.Models;

namespace CommandService.models
{
    public class platform
    {
        [Key]
        [Required]
        public int Id {get; set;}
        [Required]
        public int ExternalID { get; set; }
        [Required]
        public string  Name { get; set;}

        public ICollection<Command> Commands { get; set;} = new List<Command>();
    }
}