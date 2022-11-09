using Microsoft.AspNetCore.Mvc;

namespace MVCPortfolio.Controllers;

public class HomeController : Controller {

    public HomeController() {
    }

    public IActionResult Index() {
        return View();
    }

}
