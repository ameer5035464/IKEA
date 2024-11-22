using System.ComponentModel.DataAnnotations;

namespace Dev.Ikea.PL.ViewModels.Identity
{
	public class SignUpViewModel
	{
		[Required]
		[Display(Name = "First Name")]
		public string FName { get; set; } = null!;

		[Display(Name = "Last Name")]
		public string LName { get; set; } = null!;

        [Display(Name = "User Name")]
		public string UserName { get; set; } = null!;

		[EmailAddress]
		public string Email { get; set; } = null!;

		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;

		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password")]
		[Compare("Password", ErrorMessage = "There Is Difrrences")]
		public string Confirmpassword { get; set; } = null!;

		[Display(Name ="Is Agree")]
        public bool IsAgree { get; set; }
    }
}
