using System.ComponentModel.DataAnnotations;

namespace Dev.Ikea.PL.ViewModels.Identity
{
	public class ResetPasswordViewModel
	{
		[DataType(DataType.Password,ErrorMessage ="Invalid Password")]
		[Display(Name ="New Password")]
		public string NewPassword { get; set; } = null!;

		[DataType(DataType.Password, ErrorMessage = "Invalid Password")]
		[Display(Name = "Confirm Password")]
		[Compare("NewPassword",ErrorMessage ="Not Matched")]
		public string ConfirmPassword { get; set; } = null!;
    }
}
