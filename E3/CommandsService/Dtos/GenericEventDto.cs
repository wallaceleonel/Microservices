using CommandService.EventProcessing;

namespace CommandService.Dtos
{
    public class GenericEventDto
    {
        public string Event { get; set; }
        internal EventType PlatformPublished { get; set; }
        
        internal EventType Undetermined { get; set; }
    }
}