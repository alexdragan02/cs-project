using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers;

public class TeamController : Controller
{
    public IActionResult Index()
    {
        return View("~/Views/Home/Team.cshtml", _barbers);
    }

    public static readonly List<Barber> _barbers = new()
    {
        new Barber
        {
            Id = 1,
            Name = "Alexandru Popescu",
            Experience = "8 ani experiență",
            Image = "https://images.unsplash.com/photo-1621605815971-fbc98d665033?w=500",
            Rating = 4.9,
            Bio = "Master barber cu specializare în Paris."
        }
    };
}
