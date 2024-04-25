using CoffeeShopRegistration.Models;

namespace CoffeeShopRegistration.DAL
{
	public class ProductsRepository
	{
		private readonly CoffeeShopContext _context;
		public ProductsRepository (CoffeeShopContext context)
		{
			_context = context;
		}

		//Get all products
		public List<Product> GetAllProducts()
		{
			return _context.Products.ToList();
		}

		public List<Product> GetProductsByCategory(string category)
		{
			return _context.Products.Where(a => a.Category == category).ToList();
		}


		public List<string> GetAllCategories()
		{
			return _context.Products.Select(b => b.Category).Distinct().ToList();
		}
		public void AddProduct(Product product)
		{
			_context.Products.Add(product);
			_context.SaveChanges();
		}
		public void RemoveProduct(int id) 
		{ 
			var product = _context.Products.Find(id);
            if (product != null)
			{
				_context.Products.Remove(product);
				_context.SaveChanges();
			}
            
        }

	}
}
