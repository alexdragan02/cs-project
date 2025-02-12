using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Interfaces.Services;
using Project.Models;

namespace Project.Controllers;

public class HomeController : Controller
{
    private readonly IMessageService _messageService;

    public HomeController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> Contact()
    {
        var messages = await _messageService.GetMessagesAsync();
        return View(messages);
    }

    [HttpPost]
    public async Task<IActionResult> ContactPost(Message message)
    {
        if (ModelState.IsValid)
        {
            await _messageService.AddMessagesAsync(message, Request.Form.Files[0]);
            return RedirectToAction(nameof(Contact));
        }

        // Ensure the model state errors are passed back to the view
        var messages = await _messageService.GetMessagesAsync();
        return View(nameof(Contact), messages);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var message = await _messageService.GetMessageByIdAsync(id);
        if (message == null)
        {
            return NotFound();
        }
        await _messageService.RemoveMessagesAsync(message);
        return RedirectToAction(nameof(Contact));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var message = await _messageService.GetMessageByIdAsync(id);
        if (message == null)
        {
            return NotFound();
        }
        return View(message);
    }

    public async Task<IActionResult> Update(Message newMessage)
    {
        var oldMessage = await _messageService.GetMessageByIdAsync(newMessage.Id);
        if (oldMessage == null)
        {
            return NotFound();
        }

        await _messageService.UpdateMessagesAsync(oldMessage, newMessage);
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
