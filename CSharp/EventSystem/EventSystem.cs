using System;
using System.Collections.Generic;

namespace EventSystem
{
    class EventSystem
    {
        private Dictionary<Type, List<MulticastDelegate>> _callbacks = new Dictionary<Type, List<MulticastDelegate>>();

        public void Subscribe<TEvent>(Action<TEvent> callback) where TEvent : Event
        {
            if (_callbacks.TryGetValue(typeof(TEvent), out List<MulticastDelegate> callbacks) == false)
            {
                callbacks = new List<MulticastDelegate>();
                _callbacks.Add(typeof(TEvent), callbacks);
            }
            callbacks.Add(callback);
        }

        public void Publish<TEvent>(TEvent e) where TEvent : Event
        {
            if (_callbacks.TryGetValue(typeof(TEvent), out List<MulticastDelegate> callbacks))
            {
                callbacks.ForEach(callback => ((Action<TEvent>)callback)(e));
            }
        }
    }
}