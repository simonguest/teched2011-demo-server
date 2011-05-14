using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TechEdDemoMVC.Models;
using System.Data.Objects.DataClasses;

namespace TechEdDemoMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to TechEd!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Reset()
        {
            SessionModelContainer ctx = new SessionModelContainer();

            // First let's get rid of the old data
            List<Session> sessionsToBeDeleted = ctx.Sessions.ToList();
            foreach (Session session in sessionsToBeDeleted)
            {
                session.PrimarySpeakers.Clear();
                session.AssistantSpeakers.Clear();
                ctx.SaveChanges();
                ctx.DeleteObject(session);
            }
            ctx.SaveChanges();

            List<Speaker> speakersToBeDeleted = ctx.Speakers.ToList();
            foreach (Speaker speaker in speakersToBeDeleted)
            {
                ctx.DeleteObject(speaker);
            }
            ctx.SaveChanges();

            List<Timeslot> timeslotsToBeDeleted = ctx.Timeslots.ToList();
            foreach (Timeslot timeslot in timeslotsToBeDeleted)
            {
                ctx.DeleteObject(timeslot);
            }
            ctx.SaveChanges();

            // Create the new sample data for the demo
            Timeslot mySlot = new Timeslot() { Name = "Timeslot 15", Start = new DateTime(2011, 5, 17, 13, 30, 0), End = new DateTime(2011, 5, 17, 14, 45, 0) };

            mySlot.Sessions.Add(new Session()
            {
                Code = "BOF06-DEV",
                Title = "How on Earth Do I Keep Up with All the New Technologies That Come Along?",
                PrimarySpeakers = new EntityCollection<Speaker>() { new Speaker("Peter Mourfield") },
                Room = "B209"
            });

            mySlot.Sessions.Add(new Session()
            {
                Code = "BOF06-ITP",
                Title = "When Is Cloud an Option?",
                PrimarySpeakers = new EntityCollection<Speaker>() { new Speaker("Dmitry Sotnikov") },
                Room = "B210"
            });

            mySlot.Sessions.Add(new Session()
            {
                Code = "COS315",
                Title = "Building Windows Phone Applications with the Windows Azure Platform",
                PrimarySpeakers = new EntityCollection<Speaker>() { new Speaker("Wade Wegner") },
                Room = "C211"
            });

            mySlot.Sessions.Add(new Session()
            {
                Code = "DBI211",
                Title = "What’s New in Microsoft SQL Server Code-Named Denali for Reporting Services",
                PrimarySpeakers = new EntityCollection<Speaker>() { new Speaker("Ariel Netz") },
                Room = "C203"
            });

            mySlot.Sessions.Add(new Session()
            {
                Code = "DBI304",
                Title = "What's New in Manageability for Microsoft SQL Server Code- Named Denali",
                PrimarySpeakers = new EntityCollection<Speaker>() { new Speaker("Denny Cherry") },
                Room = "B207"
            });

            mySlot.Sessions.Add(new Session()
            {
                Code = "DBI323",
                Title = "Using Cloud (Microsoft SQL Azure) and PowerPivot to Deliver Data and Self-Service BI at Microsoft",
                PrimarySpeakers = new EntityCollection<Speaker>() { new Speaker("Diana Putnam") },
                Room = "C208"
            });

            mySlot.Sessions.Add(new Session()
            {
                Code = "DEV209",
                Title = "From Zero to Silverlight in 75 Minutes",
                PrimarySpeakers = new EntityCollection<Speaker>() { new Speaker("Paul Sheriff") },
                Room = "C305"
            });

            mySlot.Sessions.Add(new Session()
            {
                Code = "DEV304",
                Title = "Advanced Programming Patterns for Windows 7",
                PrimarySpeakers = new EntityCollection<Speaker>() { new Speaker("Kate Gregory") },
                Room = "B103"
            });

            mySlot.Sessions.Add(new Session()
            {
                Code = "DEV306",
                Title = "Branching and Merging for Parallel Development",
                PrimarySpeakers = new EntityCollection<Speaker>() { new Speaker("Jeff Levinson") },
                Room = "B101"
            });

            mySlot.Sessions.Add(new Session()
            {
                Code = "DEV345",
                Title = "Writing an ASP.NET MVC View Engine",
                PrimarySpeakers = new EntityCollection<Speaker>() { new Speaker("Louis DeJardin") },
                Room = "B211"
            });

            mySlot.Sessions.Add(new Session()
            {
                Code = "DEV355",
                Title = "Orchard 1.1: Build, Customize, Extend, Ship",
                PrimarySpeakers = new EntityCollection<Speaker>() { new Speaker("Sebastien Ros") },
                Room = "C205"
            });

            mySlot.Sessions.Add(new Session()
            {
                Code = "DPR209",
                Title = "Fundamental Design Principles for UI Developers",
                PrimarySpeakers = new EntityCollection<Speaker>() { new Speaker("Billy Hollis") },
                Room = "B406"
            });

            mySlot.Sessions.Add(new Session()
            {
                Code = "DPR304",
                Title = "My Customers Are Using iPhone/Android, but I'm a Microsoft Guy. Now What?",
                PrimarySpeakers = new EntityCollection<Speaker>() { new Speaker("Simon Guest") },
                Room = "Georgia Ballroom 1"
            });

            mySlot.Sessions.Add(new Session()
            {
                Code = "EXL307",
                Title = "Load Balancing with Microsoft Exchange Server 2010",
                PrimarySpeakers = new EntityCollection<Speaker>() { new Speaker("Andrew Ehrensing") },
                Room = "B206"
            });

            mySlot.Sessions.Add(new Session()
            {
                Code = "MID201",
                Title = "An Overview of the Microsoft Middleware Strategy",
                PrimarySpeakers = new EntityCollection<Speaker>() { new Speaker("Robert Dimpsey") },
                Room = "B314"
            });

            mySlot.Sessions.Add(new Session()
            {
                Code = "OSP213",
                Title = "What Do Existing BPOS Customers Need to Do to Prepare for Microsoft Office 365?",
                PrimarySpeakers = new EntityCollection<Speaker>() { new Speaker("Erik Ashby") },
                Room = "B314"
            });

            // create context and add
            ctx.AddToTimeslots(mySlot);
            ctx.SaveChanges();

            ViewBag.Message = "Sample data reset and loaded.";

            return View("Index");
        }
    }
}
