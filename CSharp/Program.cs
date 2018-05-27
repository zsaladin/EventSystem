using System;

namespace EventSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            EventSystem eventSystem = new EventSystem();

            eventSystem.Subscribe<Event_CreateBlock>(Callback10, 10);
            eventSystem.Subscribe<Event_CreateBlock>(Callback0);

            eventSystem.Subscribe<Event_CreateTransaction>(Callback0);
            eventSystem.Subscribe<Event_CreateTransaction>(Callback10, 10);

            Event_CreateBlock event0 = new Event_CreateBlock();
            event0.BlockHash = "abc";

            Event_CreateTransaction event1 = new Event_CreateTransaction();
            event1.TxHash = "123";

            eventSystem.Publish(event0);
            eventSystem.Publish(event1);
        }

        static void Callback0(Event_CreateBlock e)
        {
            Console.WriteLine($"Order 0, {e.BlockHash}");
        }

        static void Callback10(Event_CreateBlock e)
        {
            Console.WriteLine($"Order 10, {e.BlockHash}");
        }

        static void Callback0(Event_CreateTransaction e)
        {
            Console.WriteLine($"Order 0, {e.TxHash}");
        }

        static void Callback10(Event_CreateTransaction e)
        {
            Console.WriteLine($"Order 10, {e.TxHash}");
        }
    }
}
