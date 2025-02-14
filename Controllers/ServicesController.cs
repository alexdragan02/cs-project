using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers;

public class ServicesController : Controller
{
    public IActionResult Index()
    {
        return View("~/Views/Home/Services.cshtml", _services);
    }

    public static readonly List<Service> _services = []
    {
        new Service
        {
            Id = 1,
            Name = "Tuns Normal",
            Price = 40,
            Duration = "30 min",
            Description = "Tunsoare clasică ce include consultație, spălat, tuns și aranjat.",
            Image = "https://images.unsplash.com/photo-1585747860715-2ba37e788b70?w=800",
        },
        new Service
        {
            Id = 2,
            Name = "Tuns + Barbă",
            Price = 60,
            Duration = "45 min",
            Description = "Serviciu complet pentru gentleman-ul modern.",
            Image = "https://images.unsplash.com/photo-1621605815971-fbc98d665033?w=800",
        }
    };
}
