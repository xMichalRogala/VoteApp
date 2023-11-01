﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;
using VoteApp.Backend.CQRS.Events.Abstract;
using VoteApp.Backend.CQRS.Events.Models;

namespace VoteApp.Backend.CQRS.Events.Concrete
{
    public class EventQueueManager
    {
        private readonly IEventDispatcher _eventDispatcher;
        private readonly ConcurrentBag<IEvent> _events = new ConcurrentBag<IEvent>();
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly EventOptions _eventOptions;
        private List<Task> _tasks = new List<Task>();
        private readonly ILogger<EventQueueManager> _logger;
        public bool IsManagerWorking { get; private set; } = false;

        public EventQueueManager(IEventDispatcher eventDispatcher, IOptions<EventOptions> eventOptions, ILogger<EventQueueManager> logger)
        {
            _eventDispatcher = eventDispatcher;
            _cancellationTokenSource = new CancellationTokenSource();
            _eventOptions = eventOptions.Value;
            _logger = logger;
        }

        public Task AddEventToQueue(IEvent @event)
        {
            _events.Add(@event);

            return Task.CompletedTask;
        }

        public async Task AddEventsToQueue(IEnumerable<IEvent> events)
        {
            foreach(var @event in events)
            {
                await AddEventToQueue(@event);
            }
        }

        public async Task StartWorkAsync(CancellationToken cancellationToken = default)
        {
            //todo check that only one loop is running, semaphor etc
            _logger.LogInformation($"{nameof(EventQueueManager)} has started");
            IsManagerWorking = true;

            while(true)
            {
                if (_cancellationTokenSource.IsCancellationRequested || cancellationToken.IsCancellationRequested)
                {
                    Task tasks = Task.WhenAll(_tasks);

                    try
                    {
                        tasks.Wait();
                    }
                    catch(Exception ex) 
                    { 
                        _logger.LogInformation($"{nameof(EventQueueManager)} exception -> {ex.ToString()}"); 
                    }

                    IsManagerWorking= false;
                    break;
                }

                if(_tasks.Count < _eventOptions.ParallelDegree && _events.Count > 0)
                {
                    var task = Task.Factory.StartNew(async () =>
                    {
                        if(_events.TryTake(out IEvent? @event))
                        {
                            if (@event != null)
                            {
                                var eventType = @event.GetType();
                                await _eventDispatcher.DispatchAsync(@event, _cancellationTokenSource.Token);
                            }                           
                        }    
                    });

                    _tasks.Add(task);
                }
                else if(_tasks.Count > 0)
                {
                    _tasks.RemoveAll(task => task.IsCompleted);
                }

                await Task.Delay(_eventOptions.Delay);
            }
        }

        public void StopWork()
        {
            _logger.LogInformation($"{nameof(EventQueueManager)} has stopped");
            _cancellationTokenSource.Cancel();
        }
    }
}
