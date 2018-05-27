namespace EventSystem
{
    class Event
    {
        public class CreateTransaction : Event
        {
            public string TxHash { get; set; }
        }

        public class CreateBlock : Event
        {
            public string BlockHash { get; set; }
        }
    }
}