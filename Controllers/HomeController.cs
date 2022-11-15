using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCPortfolio.Models.Interfaces;

namespace MVCPortfolio.Controllers;

public class HomeController : Controller {

    private readonly IWeatherService _weatherService;

    public HomeController(IWeatherService _weatherService) {
        this._weatherService = _weatherService;
    }

    [HttpGet]
    public IActionResult Index() {
        return View();
    }
    
    [HttpGet]
    [Route("search")]
    public async Task<IActionResult> SearchView(string location) {
        return View(await _weatherService.GetWeatherAsync(location));
    }

    [Authorize]
    [HttpGet]
    [Route("secret/{id}")]
    public IActionResult SuperSecret(int id) {
        return View(id);
    }
}
