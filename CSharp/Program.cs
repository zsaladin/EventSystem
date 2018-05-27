using System;

namespace EventSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            EventSystem eventSystem = new EventSystem();

            eventSystem.Subscribe<Event.CreateBlock>(Callback10, 10);
            eventSystem.Subscribe<Event.CreateBlock>(Callback0);

            eventSystem.Subscribe<Event.CreateTransaction>(Callback0);
            eventSystem.Subscribe<Event.CreateTransaction>(Callback10, 10);

            Event.CreateBlock event0 = new Event.CreateBlock();
            event0.BlockHash = "abc";

            Event.CreateTransaction event1 = new Event.CreateTransaction();
            event1.TxHash = "123";

            eventSystem.Publish(event0);
            eventSystem.Publish(event1);
        }

        static void Callback0(Event.CreateBlock e)
        {
            Console.WriteLine($"Order 0, {e.BlockHash}");
        }

        static void Callback10(Event.CreateBlock e)
        {
            Console.WriteLine($"Order 10, {e.BlockHash}");
        }

        static void Callback0(Event.CreateTransaction e)
        {
            Console.WriteLine($"Order 0, {e.TxHash}");
        }

        static void Callback10(Event.CreateTransaction e)
        {
            Console.WriteLine($"Order 10, {e.TxHash}");
        }
    }
}
