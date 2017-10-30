using System;
using Microsoft.AspNetCore.Mvc;
using WebJobDemo.Web.ViewModels;
using WebJobDemo.Web.Services;
using WebJobDemo.Models;

namespace WebJobDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStorageQueueService _storageQueueSvc;

        /// <summary>
        /// Constructor
        /// </summary>
        public HomeController(IStorageQueueService storageQueueSvc)
        {
            _storageQueueSvc = storageQueueSvc;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Called when the user submits a message to send to our WebJob. This method
        /// passes the message to our StorageQueueService for enqueueing. 
        /// </summary>
        [HttpPost]
        public IActionResult Index(QueueMessageViewModel model)
        {
            model.LastPostStatus = string.Empty;
            if (!string.IsNullOrEmpty(model.StorageQueueMessage))
            {
                //the user has supplied a message. Place the message inside a QueueMessage
                //instance and pass it to our StorageQueueService for enqueueing. 
                QueueMessage queueMsg = new QueueMessage(model.StorageQueueMessage);
                _storageQueueSvc.EnqueueMessage(queueMsg);

                //tell the user that the message was successfully processed. 
                model.LastPostStatus = "Posted the message \"" + model.StorageQueueMessage + "\" to the Storage Queue at " + DateTime.Now.ToString();
            }

            model.StorageQueueMessage = string.Empty;
            return View(model);
        }
    }
}
