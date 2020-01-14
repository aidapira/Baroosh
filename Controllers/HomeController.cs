using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Baroosh.Models;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
// using MailKit.Net.Smtp;
// using MimeKit;
// using MailKit.Security;
// using static MailKit.Net.Smtp.SmtpClient;

namespace Baroosh.Controllers
{
    public class HomeController : Controller
    {
        private MyContext DbContext;
        public HomeController(MyContext context)
        {
            DbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("message")]
        public IActionResult sendEmail(string name, string email, string content){
            MimeMessage message = new MimeMessage();
            MailboxAddress from = new MailboxAddress(name, email);
            message.From.Add(from);
            MailboxAddress to = new MailboxAddress("Shop","aidapa1995@gmail.com");
            message.To.Add(to);
            message.Subject = "Email from website";
            BodyBuilder bod = new BodyBuilder();
            content = content+"\n"+email;
            bod.TextBody = content;
            message.Body = bod.ToMessageBody();
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com",587,SecureSocketOptions.StartTls);
            client.Authenticate("aidapa1995@gmail.com","");
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
            return RedirectToAction("");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
