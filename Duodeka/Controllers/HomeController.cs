using DataAccessLayer;
using DataAccessLayer.Services;
using Duodeka.Models;
using DuodekaBusiness.Pages;
using DuodekaModels.Items;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Duodeka.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IItemService itemService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            itemService = new DatabaseContext();
        }

        public IActionResult Index()
        {
            MainPageModel model = new PageService().GetMainPage();

            return View(model ); //returns both treerows and itemindir rows
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