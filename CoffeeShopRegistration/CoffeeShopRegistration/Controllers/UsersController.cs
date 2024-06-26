﻿using CoffeeShopRegistration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
				DrinkId = 1,
				MemberShipId = 2,
				IsReferred = true,		 
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
			IEnumerable<Drink> drinks = GetDrinks();
			IEnumerable<MemberShip> memberShips = GetMemberShips();
			Drink drink = drinks.FirstOrDefault(x=>x.Id ==user.DrinkId);
			MemberShip memberShip = memberShips.FirstOrDefault(x => x.Id == user.MemberShipId);
			ViewBag.DrinkText = drink == null ? "" : drink.Name;
			ViewBag.MemberShipText = memberShip == null? "": memberShip.Name;
			return View(user);
		}

		/*[HttpGet]
		public IActionResult Create()
		{
			return View();
		}*/

		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.Memberships = new SelectList(GetMemberShips(), "Id", "Name");
			ViewBag.Drinks = new SelectList(GetDrinks(), "Id", "Name");
			return View();
		}

		[HttpPost]		
		public IActionResult Create(User user)
		{
			if (ModelState.IsValid)
			{
				user.Id = _users.Max(x => x.Id) + 1;
				_users.Add(user);
				//ViewBag.ResultMessage = $"{user.FirstName} has been regisered.";
				return RedirectToAction("Welcome", user);
			}
			ViewBag.ResultMessage = $"There was a problem registering {user.FirstName}.";
			ViewBag.Drinks = new SelectList(GetDrinks(), "Id", "Name");
			ViewBag.MemberShips = new SelectList(GetMemberShips(), "Id", "Name");
			return View(user);
			
		}
		[HttpGet]
		public IActionResult Welcome(User user) 
		{ 
			return View(user);
		}
		
		private IEnumerable<Drink> GetDrinks()
		{
			return new List<Drink>()
			{
				new Drink{ Id = 1, Name = "Latte"},
				new Drink{ Id = 2, Name = "Espresso"},
				new Drink{ Id = 3, Name = "Cappuccino"}
			};
		}
		private IEnumerable<MemberShip> GetMemberShips()
		{
			return new List<MemberShip>()
			{
				new MemberShip{ Id = 1, Name = "Monthly"},
				new MemberShip{ Id = 2, Name = "Quarterly"},
				new MemberShip{ Id = 3, Name = "Yearly"},
				new MemberShip{ Id = 4, Name = "Guest"}
			};
		}
	}
}
