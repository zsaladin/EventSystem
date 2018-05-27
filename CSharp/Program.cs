using System;

namespace EventSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            EventSystem eventSystem = new EventSystem();
            eventSystem.Subscribe<Event_CreateBlock>(callback);
            eventSystem.Subscribe<Event_CreateTransaction>(callback);

            Event_CreateBlock event0 = new Event_CreateBlock();
            event0.BlockHash = "abc";

            Event_CreateTransaction event1 = new Event_CreateTransaction();
            event1.TxHash = "bcd";

            eventSystem.Publish(event0);
            eventSystem.Publish(event1);
        }

        static void callback(Event_CreateBlock e)
        {
            Console.WriteLine(e.BlockHash);
        }

        static void callback(Event_CreateTransaction e)
        {
            Console.WriteLine(e.TxHash);
        }
    }
}
