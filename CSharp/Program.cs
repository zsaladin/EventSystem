using System;

namespace EventSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        EventSystem _eventSystem = new EventSystem();
        Program()
        {
            Subscribe();
            Publish();
        }

        void Subscribe()
        {
            _eventSystem.Subscribe<Event.CreateBlock>(Callback10, 10);
            _eventSystem.Subscribe<Event.CreateBlock>(Callback0);

            _eventSystem.Subscribe<Event.CreateTransaction>(Callback0);
            _eventSystem.Subscribe<Event.CreateTransaction>(Callback10, 10);
        }

        void Publish()
        {
            Event.CreateBlock event0 = new Event.CreateBlock();
            event0.BlockHash = "abc";

            Event.CreateTransaction event1 = new Event.CreateTransaction();
            event1.TxHash = "123";

            _eventSystem.Publish(event0);
            _eventSystem.Publish(event1);
        }

        void Callback0(Event.CreateBlock e)
        {
            Console.WriteLine($"Order 0, {e.BlockHash}");
        }

        void Callback10(Event.CreateBlock e)
        {
            Console.WriteLine($"Order 10, {e.BlockHash}");
        }

        void Callback0(Event.CreateTransaction e)
        {
            Console.WriteLine($"Order 0, {e.TxHash}");
        }

        void Callback10(Event.CreateTransaction e)
        {
            Console.WriteLine($"Order 10, {e.TxHash}");
        }
    }
}
