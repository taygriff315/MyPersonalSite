using MyPersonalSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MyPersonalSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Resume()
        {
            

            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult Team()
        {
            return View();
        }

        public ActionResult Contact()
        {
            

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {

            if (ModelState.IsValid)
            {
                return View(cvm);
            }

            string message = $"You have recieved an email from {cvm.Name}. Subject: {cvm.Subject}. Respond to {cvm.EmailAddress}. Message: {cvm.Message}";

            MailMessage mm = new MailMessage("admin@tpgcode.com", "titleist315@gmail.com", cvm.Subject, cvm.Message);

            mm.IsBodyHtml = true;

            mm.ReplyToList.Add(cvm.EmailAddress);

            SmtpClient client = new SmtpClient("mail.tpgcode.com");

            client.Credentials = new NetworkCredential("admin@tpgcode.com", "P@ssw0rd");

            try
            {
                client.Send(mm);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Your message could not be sent at this time. Please try again later." +
                    $"<br/> Errors message: <br/>{ex.Message}.";

                return View(cvm);
            }

            return View("EmailConfirmation", cvm);

        }
        
    }
}