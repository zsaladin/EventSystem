namespace EventSystem
{
    class Event
    {
    }

    class Event_CreateTransaction : Event
    {
        public string TxHash { get; set; }
    }

    class Event_CreateBlock : Event
    {
        public string BlockHash { get; set; }
    }
}