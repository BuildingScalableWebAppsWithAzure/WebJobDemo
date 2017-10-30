namespace WebJobDemo.Models
{
    /// <summary>
    /// This class contains information sent as a queue message. We are using this class as the model
    /// for both Service Bus Queues and Azure Storage Queues. The reason we're using a class instead of just passing in 
    /// a string as the payload for both queue types is that it's useful to know how to serialize, pass, and deserialize
    /// an object instance. This is much more applicable to real world examples. 
    /// </summary>
    public class QueueMessage
    {
        public QueueMessage()
        { }

        public QueueMessage(string message)
        {
            this.Message = message;
        }

        /// <summary>
        /// Contains our actual message.
        /// </summary>
        public string Message { get; set; }
    }
}
