using Microsoft.AspNetCore.Mvc;
using Mvc.Services;

namespace Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Service _service;

    public HomeController(ILogger<HomeController> logger, Service service)
    {
        _logger = logger;
        _service = service;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string inputText)
    {
        try
        {
            ViewBag.duplicateNumbers = _service.FindDuplicates(inputText);

            return View("Result");
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, null);
            return View("Error");
        }

    }

    public IActionResult Error()
    {
        return View();
    }
}
