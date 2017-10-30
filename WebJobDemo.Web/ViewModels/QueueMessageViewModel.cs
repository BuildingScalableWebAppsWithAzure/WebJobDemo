namespace WebJobDemo.Web.ViewModels
{
    /// <summary>
    /// This class carries data back and forth between our HomeController methods
    /// and our strongly typed view. 
    /// </summary>
    public class QueueMessageViewModel
    {
        public string StorageQueueMessage { get; set; }
        public string LastPostStatus { get; set; }
    }
}
