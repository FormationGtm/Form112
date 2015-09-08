using Form112.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Model;

namespace Form112.Areas.Admin.Controllers
{
    public class MailingController : Controller
    {

        private Form112Entities db = new Form112Entities();

        // GET: Admin/Mailing
        public ActionResult Index()
        {


            return View();
        }

        [HttpPost]
        public ViewResult Sent(MailingViewModel mvm)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");  
            }

            var recipients = db.Utilisateurs.Where(u => u.InfoAbonne == true).ToList();

            foreach (var recip in recipients)
            {
                var stringRecip = string.Format("{1} {0} <{2}>", recip.Nom, recip.Prenom, recip.AspNetUsers.Email);

                var mailMsm = new MailMessage("Agence OpenSea <opensea_agence@gtm.fr>", stringRecip);
                mailMsm.Subject = mvm.Sujet.Replace("@Nom@", recip.Nom).Replace("@Prenom@", recip.Prenom);

                mailMsm.Body = mvm.Message.Replace("@Nom@", recip.Nom).Replace("@Prenom@", recip.Prenom);
                
                mailMsm.IsBodyHtml = true;

                var Client = new SmtpClient();
                Client.Host = "smtp.neggruda.net";
                Client.Port = 2525;
                Client.UseDefaultCredentials = false;
                Client.DeliveryMethod = SmtpDeliveryMethod.Network;
                Client.EnableSsl = false;
                Client.Credentials = new NetworkCredential("formationgtm@neggruda.net", "7VfrdsAw");
                Client.Send(mailMsm);
            }

            return View(mvm);
        }
    }
}