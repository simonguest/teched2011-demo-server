using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TechEdDemoMVC.Models;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure;

namespace TechEdDemoMVC.Controllers
{
    public class SessionController : Controller
    {
        public ActionResult Index()
        {
            SessionModelContainer ctx = new SessionModelContainer();
            return View(ctx.Sessions);
        }

        public ActionResult Lookup()
        {
            String sessionCode = Request.QueryString["session"];
            SessionModelContainer ctx = new SessionModelContainer();
            Session foundSession = ctx.Sessions.First(s => s.Code.StartsWith(sessionCode));
            return RedirectToAction("Details",new { id = foundSession.Id });
        }

        public ActionResult Details(int id)
        {
            SessionModelContainer ctx = new SessionModelContainer();
            return View(ctx.Sessions.First(s => s.Id == id));
        }

        public ActionResult Edit(int id)
        {
            SessionModelContainer ctx = new SessionModelContainer();
            return View(ctx.Sessions.First(s => s.Id == id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Session updatedSession)
        {
            SessionModelContainer ctx = new SessionModelContainer();
            Session currentSession = ctx.Sessions.First(s => s.Id == id);
            String message = currentSession.Code + ": ";
            bool changed = false;

            currentSession.Code = updatedSession.Code;
            
            if (currentSession.Title != updatedSession.Title)
            {
                currentSession.Title = updatedSession.Title;
                message += "Title changed to "+updatedSession.Title;
                changed = true;
            }
            
            if (currentSession.Room != updatedSession.Room)
            {
                currentSession.Room = updatedSession.Room;
                message += "Room changed to "+updatedSession.Room;
                changed = true;
            }

            if (changed)
            {
                // send a notification message to the queue
                StorageCredentials creds = new StorageCredentialsAccountAndKey("iostest","/9seXadQ9HwOpXUO1jKxFN8qVwluGWrRkDQS+wZrghS9a1wPNh1ysHBvj0q0zL34E/qcWkmygEBqNFSz6Yk2eA==");
                CloudQueueClient cqc = new CloudQueueClient("http://iostest.queue.core.windows.net",creds);
                var testQueue = cqc.ListQueues().First(q => q.Name.StartsWith("test"));
                testQueue.AddMessage(new CloudQueueMessage(message));
            }

            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
