using asp_tg_bot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace asp_tg_bot.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TelegramBotClient client = new TelegramBotClient("1272570778:AAF5A_WM9wSFQG3xQBD-iQo4LEQnb1mCf_Q");
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //telegram bot client
            client.OnMessage += OnMessage;
            client.StartReceiving();
            return View();
        }

        private async void OnMessage(object sender, MessageEventArgs e)
        {
            long id = e.Message.Chat.Id;
            string msg = e.Message.Text;
            await client.SendTextMessageAsync(id, msg);
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
