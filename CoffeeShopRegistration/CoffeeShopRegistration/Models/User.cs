using System.ComponentModel.DataAnnotations;

namespace CoffeeShopRegistration.Models
{
	public class User
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "First name is required")]
		[StringLength(50)]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Last name is required")]
		[StringLength(60)]
		public string LastName { get; set; }


		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid email address")]
		public string Email { get; set; }


		[Required(ErrorMessage = "Password is required")]
		[DataType(DataType.Password)]
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
					   ErrorMessage = "Password must contain at least 8 characters including " +
			"at least one uppercase letter, one lowercase letter, one digit, and one special " +
			"character.")]
		public string Password { get; set; }
	}
}
