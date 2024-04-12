using CoffeeShopRegistration.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopRegistration.Controllers
{

	public class UsersController : Controller
	{
		static List<User> _users = new List<User>
		{
			new User
			{
				Id = 1,
				FirstName = "Abby",
				LastName = "Scotts",
				Email = "ascotts@gmail.com",
				Password = "!23$F67E"
			}
		};

		[HttpGet]
		public IActionResult Index()
		{
			return View(_users);
		}

		[HttpGet]
		public IActionResult Details(int id)
		{
			var user = _users.FirstOrDefault(x => x.Id == id);
			return View(user);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]		
		public IActionResult Create(User user)
		{
			if (ModelState.IsValid)
			{
				user.Id = _users.Max(x => x.Id) + 1;
				_users.Add(user);
				return RedirectToAction("Welcome", user);
			}
			return View(user);
			
		}
		[HttpGet]
		public IActionResult Welcome(User user) 
		{ 
			return View(user);
		}
		
	}
}
