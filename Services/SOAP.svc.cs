using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using TechEdDemoMVC.Models;

namespace TechEdDemoMVC.Web.Services
{
    public class SOAP : ISOAP
    {
        public SessionSummary[] GetSessions()
        {
            List<SessionSummary> activeSessions = new List<SessionSummary>();
            SessionModelContainer ctx = new SessionModelContainer();
            foreach (Session s in ctx.Sessions)
            {
                activeSessions.Add(new SessionSummary() { Code = s.Code, Title = s.Title, PrimarySpeaker = s.PrimarySpeakers.First().Name });
            }
            return activeSessions.ToArray();
        }

        public string GetCurrentSessionCode()
        {
            return "DPR304";
        }

        public string GetTitleForCode(string code)
        {
            SessionModelContainer ctx = new SessionModelContainer();
            if (ctx.Sessions.Count(c => c.Code == code) == 0)
            {
                return "Session not found.";
            }
            else
            {
                return ctx.Sessions.First(c => c.Code == code).Title;
            }
        }
    }
}
