using System.Threading.Tasks;
using WebJobDemo.Models;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage;

namespace WebJobDemo.Web.Services
{
    public class StorageQueueService : IStorageQueueService
    {
        private readonly string _connectionString;

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="connectionString">The connection string to the Storage account that we're using.</param>
        public StorageQueueService(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Serializes queueMessage and adds it to the Storage queue webjobmessages. 
        /// </summary>
        public async Task EnqueueMessage(QueueMessage queueMessage)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_connectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            //queue names MUST be all lowercase and can only contain letters, numbers, and the dash character.
            //if you do not follow these rules, Azure will bop you over the head with a 400 Bad Request. 
            CloudQueue queue = queueClient.GetQueueReference("webjobmessages");
            await queue.CreateIfNotExistsAsync();

            //to send a class instance as a Storage Queue message payload, we must first serialize it 
            //to JSON. Newtonsoft's JsonConvert class will do the trick. 
            string serializedMsg = JsonConvert.SerializeObject(queueMessage);
            CloudQueueMessage queueMsg = new CloudQueueMessage(serializedMsg);
            await queue.AddMessageAsync(queueMsg);
        }
    }
}
