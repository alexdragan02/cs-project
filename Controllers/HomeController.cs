using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project.Interfaces.Services;
using Project.Models;

namespace Project.Controllers;

public class HomeController(IMessageService messageService) : Controller
{
    private readonly IMessageService _messageService = messageService;

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ContactPost(string email, string name, string message)
    {
        Message mesaj = new()
        {
            Email = email,
            Name = name,
            Context = message,
        };

        await _messageService.AddMessagesAsync(mesaj);

        return RedirectToAction(nameof(Contact));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }
}
