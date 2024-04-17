using System.ComponentModel.DataAnnotations;

namespace CoffeeShopRegistration.Models
{
	public class Drink
	{
		public int Id { get; set; }

		[Display(Name="Go-to Drink")]
		public string Name { get; set; }
	}
}
