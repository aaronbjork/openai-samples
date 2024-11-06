using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using openai_samples.Models;
using OpenAI.Chat;



namespace openai_samples.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ChatClient client = new(model: "gpt-4o-mini",  apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")); 

        ChatCompletion chatCompletion = client.CompleteChat("Say 'this is a test.'");
        ViewData.Add("response", chatCompletion.Content[0].Text);
 
        return View();
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
