using System.ComponentModel.DataAnnotations;

namespace Dev.Ikea.PL.ViewModels.Identity
{
	public class ForgetPasswordViewModel
	{

		[EmailAddress(ErrorMessage ="Not a Valid Email Bro!")]
		public string Email { get; set; } = null!;
    }
}
