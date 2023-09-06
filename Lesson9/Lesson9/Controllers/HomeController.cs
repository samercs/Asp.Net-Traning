using Lesson9.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Lesson9.Service;

namespace Lesson9.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService;

        public HomeController(ILogger<HomeController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            _productService.AddProduct(1,"Product1", (decimal)10.5);
            _productService.AddProduct(2, "Product2", (decimal)10.5);
            _productService.AddProduct(3, "Product3", (decimal)10.5);
            _productService.Update(2, "New Product 2", (decimal)99.9);
            return View(_productService.GetProducts());
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