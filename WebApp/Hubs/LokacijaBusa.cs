using JGSPNSWebApp.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace JGSPNSWebApp.Hubs
{
    [HubName("LokacijaBusa")]
    public class LokacijaBusa : Hub
    {
        public void Hello(List<Stanica> stanice)
        {
            foreach (var v in stanice)
            {
                double[] temp0 = { v.Lat, v.Lon };
                Clients.All.hello(temp0);
                Thread.Sleep(2000);
            }
        }
    }
}