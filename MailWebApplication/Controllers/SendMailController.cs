using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using MailWebApplication.Models;

namespace MailWebApplication.Controllers
{
    public class SendMailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(EmailRequest emailRequest)
        {
            var ToEmail = emailRequest.ToEmail;
            var Subject = emailRequest.Subject;
            var Body = emailRequest.Body;
              string textBody = " <table border='1'><tr> "+
                                "<th>Company Name</th>" +
                                "<th>Country</th>" +
                                "<th>Your Full Name</th>" +
                                "<th>Position in your Company</th>" +
                                "<th>Phone Number</th>" +
                                "<th>Email Address</th>" +
                                "</tr>" +
                                "<tr>" +
                                "<td>TCS</td>" +
                                "<td>India</td>" +
                                "<td>Akshay Sutar</td>" +
                                "<td>Developer</td>" +
                                "<td>9503775217</td>" +
                                "<td>akshay.sutar@tcs.com</td>" +
                                "</tr></table>"              ;
            MailMessage mailMessage  = new MailMessage();
            mailMessage.Subject = Subject;
            mailMessage.Body = textBody;
            mailMessage.To.Add(ToEmail);
            mailMessage.From = new MailAddress("akkystr@gmail.com");
            mailMessage.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("akkystr@gmail.com", "Iloveakshaysutar@2");
            smtp.Send(mailMessage);

            ViewBag.message = "The mail has been sent to " + mailMessage.To + "successfully";



            return View();
        }
    }
}
