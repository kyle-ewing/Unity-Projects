using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrozenCircle.Core.Services;
using FrozenCircle.Core.Utils;
using UnityEngine;

namespace BoringSpace.Services
{
    public interface IEvent
    {
    }

    public class EventManager : IService, IInitializable
    {
        private List<EventHolder> eventHolders = new List<EventHolder>();

        public void RegisterListener<TEventType>(Action<IEvent> listener) where TEventType : IEvent
        {
            var eventType = typeof(TEventType);
            var eventHolder = eventHolders.FirstOrDefault(x => x.eventType == eventType);
            if (eventHolder == null)
            {
                eventHolder = new EventHolder();
                eventHolder.eventType = eventType;
                eventHolders.Add(eventHolder);
            }

            eventHolder.eventListeners.Add(listener);
            Debug.Log($"Listener created for {eventType}");
        }

        public void UnregisterListener<TEventType>(Action<IEvent> listener) where TEventType : IEvent
        {
            var eventType = typeof(TEventType);
            var eventHolder = eventHolders.FirstOrDefault(x => x.eventType == eventType);
            if (eventHolder == null)
            {
                Debug.LogError($"No event holder found for {eventType}");
                return;
            }

            eventHolder.eventListeners.Remove(listener);
        }

        public void FireEvent<TEventType>(TEventType eventToFire) where TEventType : IEvent
        {
            var eventType = typeof(TEventType);
            var eventHolder = eventHolders.FirstOrDefault(x => x.eventType == eventType);
            if (eventHolder == null)
            {
                Debug.LogError($"No event holder found for {eventType}");
                return;
            }

            eventHolder.eventListeners.ForEach(x => x.Invoke(eventToFire));
        }

        private void Uninitialize()
        {
            Debug.LogError("Shutting down the demo event manager");
            Application.quitting -= Uninitialize;
            eventHolders.ForEach(x => x.Dispose());
        }

        public void Dispose()
        {
            Uninitialize();
        }

        public Task Initialize()
        {
            Debug.Log("EventManager.Initialize");
            eventHolders = new List<EventHolder>();
            return Task.CompletedTask;
        }
    }

    public class EventHolder : IDisposable
    {
        public Type eventType;
        public List<Action<IEvent>> eventListeners = new List<Action<IEvent>>();

        public void Dispose()
        {
            eventListeners = null;
        }
    }
}