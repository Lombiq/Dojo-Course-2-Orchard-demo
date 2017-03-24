using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Orchard.Tasks;

namespace DojoCourse2.Module.Services
{
    public class BackgroundTask : IBackgroundTask
    {
        public void Sweep()
        {
            Debugger.Break();
        }
    }
}