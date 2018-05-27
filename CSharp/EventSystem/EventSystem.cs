using System;
using System.Collections.Generic;

namespace EventSystem
{
    class EventSystem
    {
        class Callback
        {
            public MulticastDelegate Delegate { get; set; }
            public int Order { get; set; }
        }

        private Dictionary<Type, List<Callback>> _callbacks = new Dictionary<Type, List<Callback>>();

        public void Subscribe<TEvent>(Action<TEvent> callback, int order = 0) where TEvent : Event
        {
            if (_callbacks.TryGetValue(typeof(TEvent), out List<Callback> callbacks) == false)
            {
                callbacks = new List<Callback>();
                _callbacks.Add(typeof(TEvent), callbacks);
            }
            callbacks.Add(new Callback()
            {
                Delegate = callback,
                Order = order
            });
            callbacks.Sort((x, y) => x.Order - y.Order);
        }

        public void Publish<TEvent>(TEvent e) where TEvent : Event
        {
            if (_callbacks.TryGetValue(typeof(TEvent), out List<Callback> callbacks))
            {
                callbacks.ForEach(callback => ((Action<TEvent>)callback.Delegate)(e));
            }
        }
    }
}