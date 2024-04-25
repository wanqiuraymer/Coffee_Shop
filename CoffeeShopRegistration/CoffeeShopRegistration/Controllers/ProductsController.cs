using CoffeeShopRegistration.DAL;
using CoffeeShopRegistration.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopRegistration.Controllers
{
	public class ProductsController : Controller
	{
		private readonly ProductsRepository _repo;
		
		public ProductsController(CoffeeShopContext context) 
		{
			_repo = new ProductsRepository(context);
		}
		public IActionResult Index()
		{
			List<string> categories = _repo.GetAllCategories();
			IndexViewModel indexViewModel = new IndexViewModel();
			indexViewModel.Categories = categories;
			return View(indexViewModel);
		}
		public IActionResult AddProduct() 
		{ 
			return View(); 
		}

		[HttpPost]
		public IActionResult AddProduct(Product product)
		{
			_repo.AddProduct(product);
			return RedirectToAction("Index");
		}

		
		[HttpPost]
		public IActionResult Results(IndexViewModel indexViewModel) 
		{ 
			List<Product> products = _repo.GetProductsByCategory(indexViewModel.SelectedCategory);
			return View(products);
		}

        

        public IActionResult Details(int id)
		{
			List<Product> products = _repo.GetAllProducts();

			var product = products.FirstOrDefault(x => x.Id == id);
			
			return View(product);
		}
	
	}
}
