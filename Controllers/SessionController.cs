using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TechEdDemoMVC.Models;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Authentication;

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
                // send a push notification message to the device
                string host = "gateway.sandbox.push.apple.com";
                int port = 2195;

                // load the certificate file
                string certPath = @"c:\temp\teched_APN.p12";
                X509Certificate2 clientCert = new X509Certificate2(certPath, "Password");
                X509Certificate2Collection certCollection = new X509Certificate2Collection(clientCert);

                // open connection and connect
                TcpClient client = new TcpClient(host, port);
                SslStream sslStream = new SslStream(client.GetStream(), false);

                try
                {
                    sslStream.AuthenticateAsClient(host, certCollection, SslProtocols.Tls, false);
                }
                catch (AuthenticationException ex)
                {
                    Console.WriteLine(ex.InnerException.ToString());
                    Console.In.Read();
                    client.Close();
                    return RedirectToAction("Index");
                }

                MemoryStream memoryStream = new MemoryStream();
                BinaryWriter writer = new BinaryWriter(memoryStream);

                // construct the message
                writer.Write((byte)0);  // Command
                writer.Write((byte)0);  // First byte of device ID length
                writer.Write((byte)32); // Device id length

                String deviceId = "e18ac3b8a408e4e972e171a05cdba8f046ff3724ef999093c2b479397b8c40fe";  //Simon's iPhone

                // convert to hex and write to message
                byte[] deviceToken = new byte[deviceId.Length / 2];
                for (int i = 0; i < deviceToken.Length; i++)
                    deviceToken[i] = byte.Parse(deviceId.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
                writer.Write(deviceToken);

                // construct payload within JSON message framework
                String payload = "{\"aps\":{\"alert\":\""+message+"\",\"badge\":1}}";

                // write payload data
                writer.Write((byte)0);                  // First byte of payload length
                writer.Write((byte)payload.Length);     // Actual payload length
                byte[] b1 = System.Text.Encoding.UTF8.GetBytes(payload);
                writer.Write(b1);
                writer.Flush();

                // send across the wire
                byte[] array = memoryStream.ToArray();
                sslStream.Write(array);
                sslStream.Flush();

                // Close the client connection.
                client.Close();

                // Success
                Console.WriteLine("Message has been sent!  Please check device.");
                Console.In.Read();

            }

            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
