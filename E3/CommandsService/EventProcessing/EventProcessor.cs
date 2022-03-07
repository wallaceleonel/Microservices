using System;
using System.Text.Json;
using AutoMapper;
using CommandService.Dtos;
using Microsoft.Extensions.DependencyInjection;

namespace CommandService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory,AutoMapper.IMapper mapper)
    {
        _scopeFactory = scopeFactory;
        _mapper = mapper; 
    }
        public void ProcessEvent(string message)
        {
            throw new System.NotImplementedException();
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("---> Determining Event");

            var EventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);

            switch(EventType.Event)
            {
                case "Platform_Published":
                    Console.WriteLine("Platform Published Event Detected");
                default:
                    Console.WriteLine("---> Could not determine the event type");
                    return EventType.Undetermined;
            }
        }
    }

    enum EventType
    {
        platformPublshed,
        Undetermined
    }
}