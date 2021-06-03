using MyPersonalSite.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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

            ViewBag.testValue = "scroll";
            return View();
        }

        public ActionResult Projects()
        {
            ViewBag.testValue = "scroll";
            return View();
        }

        public ActionResult Team()
        {

            ViewBag.testValue = "scroll";
            return View();
        }

        public ActionResult Contact()
        {

            ViewBag.testValue = "scroll";
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {

            if (!ModelState.IsValid)
            {
                return View(cvm);
            }

            string message = $"You have recieved an email from {cvm.Name}. Subject: {cvm.Subject}. Respond to {cvm.EmailAddress}. Message: {cvm.Message}";

            MailMessage mm = new MailMessage(
                ConfigurationManager.AppSettings["EmailUser"].ToString(),
                ConfigurationManager.AppSettings["EmailTo"].ToString(),
                cvm.Subject,
                message
                );

            mm.IsBodyHtml = true;
            mm.Priority = MailPriority.High;
            mm.ReplyToList.Add(cvm.EmailAddress);

            SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["EmailClient"].ToString());

            client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailUser"].ToString(), ConfigurationManager.AppSettings["EmailPass"].ToString());

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
            ViewBag.testValue = "scroll";
            return View("EmailConfirmation", cvm);

        }
        
    }
}


