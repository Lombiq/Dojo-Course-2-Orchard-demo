using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Orchard.Environment;
using Orchard.Services;
using Orchard.Tasks.Scheduling;

namespace DojoCourse2.Module.Services
{
    public class ScheduledTask : IScheduledTaskHandler, IOrchardShellEvents
    {
        private readonly IScheduledTaskManager _scheduledTaskManager;
        private readonly IClock _clock;


        public ScheduledTask(IScheduledTaskManager scheduledTaskManager, IClock clock)
        {
            _scheduledTaskManager = scheduledTaskManager;
            _clock = clock;
        }


        public void Process(ScheduledTaskContext context)
        {
            if (context.Task.TaskType != "DemoTask")
            {
                return;
            }

            Debugger.Break();
        }

        public void Activated()
        {
            _scheduledTaskManager.CreateTask("DemoTask", _clock.UtcNow.AddMinutes(1), null);
        }

        public void Terminating()
        {
        }
    }
}