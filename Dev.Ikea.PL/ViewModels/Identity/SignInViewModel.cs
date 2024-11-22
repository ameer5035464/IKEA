using System.ComponentModel.DataAnnotations;

namespace Dev.Ikea.PL.ViewModels.Identity
{
	public class SignInViewModel
	{
		[Required(ErrorMessage ="its fkn required")]
		[EmailAddress]
		public string Email { get; set; } = null!;
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;

		[Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
