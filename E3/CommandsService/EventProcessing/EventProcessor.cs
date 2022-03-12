using System;
using System.Text.Json;
using AutoMapper;
using CommandService.Dtos;
using CommandService.models;
using CommandsService.Data;
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
            var EventType = DetermineEvent(message);


            switch(EventType)
            {
                case EventType.platformPublshed:
                // TO DO 
                    break;
                default:
                    break;
            }

        }

        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("---> Determining Event");

            var EventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);

            switch(EventType.Event)
            {
                case "Platform_Published":
                    Console.WriteLine("Platform Published Event Detected");
                    return EventType.PlatformPublished;
                default:
                    Console.WriteLine("---> Could not determine the event type");
                    return EventType.Undetermined;
            }
        }

        private void addPlatform (string platformPublshedMessage)
        {
            using( var scope = _scopeFactory.CreateAsyncScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<ICommandRepo>();

                var platformPublshedDto = JsonSerializer.Deserialize<PlatformPublishedDto>(platformPublshedMessage);

                try
                {
                    var plat = _mapper.Map<platform>(platformPublshedDto);
                    if(!repo.ExternalPlatformExists(plat.ExternalID))
                    {

                    }
                    else
                    {
                        Console.WriteLine("--> Platform already exisits...");
                    }
                }
                catch ( Exception ex)
                {
                    
                    Console.WriteLine($"---> Could not add Platform to DB {ex.Message} ");
                }
            }
        }
    }

    enum EventType
    {
        platformPublshed,
        Undetermined
    }
}