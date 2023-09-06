using Lesson9.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson9.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public ProductsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var productList = _appDbContext.Products
                .Where(i=>!i.IsDeleted)
                .ToList();
            return View(productList);
        }

        public IActionResult Details(int id)
        {
            var product = _appDbContext.Products.FirstOrDefault(i => i.Id == id);
            //var product2 = _appDbContext.Products.First(i => i.Id == id);
            //var products = _appDbContext.Products.SingleOrDefault(i => i.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Price(decimal price)
        {
            var products = _appDbContext.Products.Where(prod => prod.Price == price).ToList();
            return View(products);
        }

        public IActionResult Delete(int id)
        {
            var product = _appDbContext.Products.FirstOrDefault(i => i.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            //_appDbContext.Products.Remove(product);
            product.IsDeleted = true;
            product.DeletedAt = DateTime.Now;
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            var product = new Product();
            return View(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _appDbContext.Products.Add(product);
            _appDbContext.SaveChanges();
            TempData["Message"] = "Product Has been added successfully.";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = _appDbContext.Products.FirstOrDefault(i => i.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            var oldProduct = _appDbContext.Products.FirstOrDefault(i => i.Id == id);
            if (oldProduct == null)
            {
                return NotFound();
            }

            oldProduct.Name = product.Name;
            oldProduct.Price = product.Price;
            _appDbContext.SaveChanges();
            TempData["Message"] = "Product Has been updated successfully.";
            return RedirectToAction("Index");
        }
    }
}
