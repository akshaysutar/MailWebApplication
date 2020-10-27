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
            //string textBody = "</table><tr>""<td>BLAH BLAH BLAH</td></tr></table>";
            /**string textBody = " <table>< tr > "+
"<th>Company Name</th>" +
"<th>Customer Code</th>" +
"<th>Country</th>" +
"<th>Your Full Name</th>" +
"<th>Position in your Company</th>" +
"<th>Phone Number</th>" +
"<th>Email Address</th>" +
"</tr>" +
"<tr>" +
"<td>Company Name</td>" +
"<td>Customer Code</td>" +
"<td>Countdy</td>" +
"<td>Your Full Name</td>" +
"<td>Position in your Company</td>" +
"<td>Phone Number</td>" +
"<td>Email Address</td>" +
"</tr></table>"  **/             ;
            MailMessage mailMessage  = new MailMessage();
            mailMessage.Subject = Subject;
            mailMessage.Body = Body;
            mailMessage.To.Add(ToEmail);
            mailMessage.From = new MailAddress("FromEmailId");
            mailMessage.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("FromEmailId", "Your Credentials");
            smtp.Send(mailMessage);

            ViewBag.message = "The mail has been sent to " + mailMessage.To + "successfully";



            return View();
        }
    }
}
