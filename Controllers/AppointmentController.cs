using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers;

public class AppointmentController : Controller
{
    private readonly ILogger<AppointmentController> _logger;

    public AppointmentController(ILogger<AppointmentController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(int? serviceId = null, int? barberId = null)
    {
        // Inițializează listele dacă sunt null
        var services = ServicesController._services ?? new List<Service>();
        var barbers = TeamController._barbers ?? new List<Barber>();

        var service = serviceId.HasValue
            ? services.FirstOrDefault(s => s.Id == serviceId)
            : null;
        var barber = barberId.HasValue
            ? barbers.FirstOrDefault(b => b.Id == barberId)
            : null;

        ViewBag.Services = services;
        ViewBag.Barbers = barbers;
        ViewBag.SelectedService = service;
        ViewBag.SelectedBarber = barber;

        return View(new Appointment());
    }

    [HttpPost]
    public IActionResult Submit(Appointment appointment)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Services = ServicesController._services ?? new List<Service>();
            ViewBag.Barbers = TeamController._barbers ?? new List<Barber>();
            return View("Index", appointment);
        }

        // Simulare salvare în bază de date (momentan doar log)
        _logger.LogInformation("New appointment created: {@Appointment}", appointment);
        TempData["Success"] = "Programare realizată cu succes!";
        return RedirectToAction("Index", "Home");
    }
}
