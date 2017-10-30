using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Timers;
using Microsoft.Azure.WebJobs.Extensions; 
using WebJobDemo.Models;
using System.IO;
using System;

namespace WebJobDemo.WebJob
{
    /// <summary>
    /// This class contains several methods that are triggered by attributes. Uncomment functions you'd like
    /// to play with, then run this WebJob. 
    /// </summary>
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([QueueTrigger("webjobmessages")] QueueMessage message, TextWriter log)
        {
            if (message.Message == "error")
            {
                throw new Exception("Houston, we have a problem!");
            }
            Console.WriteLine(message.Message);
        }

        #region ErrorTriggers

        ///// <summary>
        ///// This method be called for uncaught exceptions thrown in this WebJob. This method will be called for each
        ///// exception that occurs. 
        ///// </summary>
        ///// <param name="filter"></param>
        //public static void SimpleErrorHandler([ErrorTrigger()] TraceFilter filter)
        //{
        //    Console.WriteLine("SimpleErrorHandler: " + filter.Message);
        //}

        ///// <summary>
        ///// By setting the ErrorTriggerAttribute's Throttle property, we can limit the number of times this method
        ///// can be triggered to a maximum of once within the Throttle timespan. 
        ///// </summary>
        ///// <param name="filter"></param>
        //public static void ThrottledErrorHandler([ErrorTrigger(Throttle = "0:2:00")] TraceFilter filter)
        //{
        //    Console.WriteLine("ThrottledErrorHandler: " + filter.Message);
        //}

        #endregion

        #region TimerTriggers

        ///// <summary>
        ///// This method will be executed by the JobHost every 30 seconds. It uses a standard chron expression
        ///// in the TimerTrigger argument. 
        ///// </summary>
        ///// <param name="timer"></param>
        //public static void ScheduledMethodUsingTimespanExpression([TimerTrigger("00:00:30")] TimerInfo timer)
        //{
        //    Console.WriteLine("Timer triggered at " + DateTime.Now);
        //}

        ///// <summary>
        ///// This method will fire every weekday (Monday - Friday) at 10:00AM. You'll be able to see the timer's next scheduled
        ///// execution when the WebJob loads. To actually see the timer fire, you may need to set the chrontab expression
        ///// to something in the next couple of minutes. 
        ///// </summary>
        //public static void ScheduledMethodUsingChronExpression([TimerTrigger("0 0 10 * * MON-FRI", UseMonitor = true, RunOnStartup = true)] TimerInfo timer)
        //{
        //    Console.WriteLine("Firing ScheduledMethodUsingChronExpression at {0}", DateTime.Now);
        //    string scheduleStatus = string.Format("Next Execution: '{0}'", timer.ScheduleStatus.Next);
        //    Console.WriteLine(scheduleStatus);
        //}

        ///// <summary>
        ///// We inherit from the DailySchedule class if we want to create our own daily schedule. 
        ///// This will set up a TimerTriggerAttribute to call a method at 2:30AM, 4:45AM, and 
        ///// 11:10:15PM every day. 
        ///// </summary>
        //public class TimerDailySchedule : DailySchedule
        //{
        //    public TimerDailySchedule() : base("2:30:00", "4:45:00", "23:10:15")
        //    {

        //    }
        //}

        ///// <summary>
        ///// Takes a type that derives from DailySchedule as an argument. You can do the same thing with 
        ///// a class that inherits from WeeklySchedule, ConstantSchedule, ChronSchedule, or WeeklySchedule. 
        ///// To run this method, make sure you also uncomment the inner TimerDailySchedule class above. 
        ///// </summary>
        //public static void ScheduledMethodUsingDailySchedule([TimerTrigger(typeof(TimerDailySchedule), RunOnStartup = true)] TimerInfo timer)
        //{
        //    Console.WriteLine("Firing ScheduledMethodUsingChronExpression at {0}", DateTime.Now);
        //    string scheduleStatus = string.Format("Next Execution: '{0}'", timer.ScheduleStatus.Next);
        //    Console.WriteLine(scheduleStatus);
        //}

        #endregion
    }
}
