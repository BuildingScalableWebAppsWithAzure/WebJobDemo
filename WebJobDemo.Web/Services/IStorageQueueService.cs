using System.Threading.Tasks;
using WebJobDemo.Models; 

namespace WebJobDemo.Web.Services
{
    public interface IStorageQueueService
    {
        Task EnqueueMessage(QueueMessage queueMessage);
    }
}
