using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

    public interface IEvent { }
    
    public static class EventManager {
        private static List<EventHolder> eventHolders = new List<EventHolder>();
        
        [RuntimeInitializeOnLoadMethod]
        public static void Initialize() {
            Debug.Log("EventManager.Initialize");
            eventHolders = new List<EventHolder>();
            Application.quitting += Uninitialize;
        }
        
        public static void RegisterListener<TEventType>(Action<IEvent> listener) where TEventType : IEvent {
            var eventType = typeof(TEventType);
            var eventHolder = eventHolders.FirstOrDefault(x => x.eventType == eventType);
            if (eventHolder == null) {
                eventHolder = new EventHolder();
                eventHolder.eventType = eventType;
                eventHolders.Add(eventHolder);
            }
            eventHolder.eventListeners.Add(listener);
            Debug.Log($"Listener created for {eventType}");
        }
        
        public static void UnregisterListener<TEventType>(Action<IEvent> listener) where TEventType : IEvent {
            var eventType = typeof(TEventType);
            var eventHolder = eventHolders.FirstOrDefault(x => x.eventType == eventType);
            if (eventHolder == null) {
                Debug.LogError($"No event holder found for {eventType}");
                return;
            }
            eventHolder.eventListeners.Remove(listener);
        }
        
        public static void FireEvent<TEventType>(TEventType eventToFire) where TEventType : IEvent {
            var eventType = typeof(TEventType);
            var eventHolder = eventHolders.FirstOrDefault(x => x.eventType == eventType);
            if (eventHolder == null) {
                Debug.LogError($"No event holder found for {eventType}");
                return;
            }
            eventHolder.eventListeners.ForEach(x => x.Invoke(eventToFire));
        }

        private static void Uninitialize() {
            Debug.LogError("Shutting down the demo event manager");
            Application.quitting -= Uninitialize;
            eventHolders.ForEach(x => x.Dispose());
        }
        
    }


    public class EventHolder : IDisposable {
        public Type eventType;
        public List<Action<IEvent>> eventListeners = new List<Action<IEvent>>();

        public void Dispose() {
            eventListeners = null;
        }
    }