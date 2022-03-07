using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace CommandService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public EventProcessor(IServiceScopeFactory scopeFactory,AutoMapper.IMapper mapper)
    {
        _scopeFactory = scopeFactory;
        _mapper = mapper; 
    }
        public void ProcessEvent(string message)
        {
            throw new System.NotImplementedException();
        }
    }

    enum EventType
    {
        platformPublshed,
        Undetermined
    }
}