using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TechEdDemoMVC.Models;

namespace TechEdDemoMVC.Web.Services
{
    public class SessionService : ISessionService
    {
        public SessionSummary[] GetData()
        {
            List<SessionSummary> sessionsOnNow = new List<SessionSummary>();

            SessionModelContainer ctx = new SessionModelContainer();
            foreach (Session session in ctx.Sessions)
            {
                sessionsOnNow.Add(new SessionSummary() { Code = session.Code, Title = session.Title, PrimarySpeaker = session.PrimarySpeakers.First().Name });
            }

            return sessionsOnNow.ToArray();
        }
    }
}