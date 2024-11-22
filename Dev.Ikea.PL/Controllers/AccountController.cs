using Dev.Ikea.DAL.Models;
using Dev.Ikea.DAL.Models.Identity;
using Dev.Ikea.PL.Helpers;
using Dev.Ikea.PL.ViewModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Dev.Ikea.PL.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationIdentityUser> _userManager;
		private readonly SignInManager<ApplicationIdentityUser> _signInManager;
		private readonly IEmailSettings _emailSettings;

		public AccountController(UserManager<ApplicationIdentityUser> userManager, SignInManager<ApplicationIdentityUser> signInManager, IEmailSettings emailSettings)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_emailSettings = emailSettings;
		}

		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpViewModel signUp)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var user1 = await _userManager.FindByNameAsync(signUp.UserName);
			var user2 = await _userManager.FindByEmailAsync(signUp.Email);


			if (user1 != null)
			{
				ModelState.AddModelError(nameof(SignUpViewModel.UserName), "User Name Already Taken");
				return View(signUp);
			}
			else if (user2 != null)
			{
				ModelState.AddModelError(nameof(SignUpViewModel.Email), "Email Already Taken");
				return View(signUp);
			}

			else
			{
				var user = new ApplicationIdentityUser
				{
					Fname = signUp.FName,
					Lname = signUp.LName,
					UserName = signUp.UserName,
					Email = signUp.Email,
					IsAgree = signUp.IsAgree
				};

				var result = await _userManager.CreateAsync(user, signUp.Password);

				if (result.Succeeded)
				{
					return RedirectToAction("SignIn");
				}

				foreach (var err in result.Errors)
				{
					ModelState.AddModelError(string.Empty, err.Description);
				}

				return View(signUp);
			}
		}

		public IActionResult SignIn()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignIn(SignInViewModel signIn, string? ReturnUrl)
		{
			if (!ModelState.IsValid)
			{
				return View(signIn);
			}

			var TryToSignUser = await _userManager.FindByEmailAsync(signIn.Email);

			if (TryToSignUser is null)
			{
				ModelState.AddModelError(string.Empty, "Email Does not EXIST!");
			}

			else if (TryToSignUser != null)
			{
				var result = await _signInManager.PasswordSignInAsync(TryToSignUser, signIn.Password, signIn.RememberMe, false);

				if (result.IsNotAllowed)
					ModelState.AddModelError(string.Empty, "You Are Missing Some Verfications");

				else if (result.IsLockedOut)
					ModelState.AddModelError(string.Empty, "Your Account is Locked");

				else if (result.RequiresTwoFactor)
					ModelState.AddModelError(string.Empty, "You Are Missing Two Factor Authentication");

				else if (signIn.Email == null || signIn.Password == null)
				{
					ModelState.AddModelError(string.Empty, "Email Or Password is Incorrect!");
					return View(signIn);
				}
				else if (!result.Succeeded)
				{
					ModelState.AddModelError(string.Empty, "Email Or Password is Incorrect!");
					return View(signIn);
				}
				else if (result.Succeeded)
				{
					if (!ReturnUrl.IsNullOrEmpty() && Url.IsLocalUrl(ReturnUrl))
					{
						ViewBag.UserEmail = TryToSignUser.Email;
						return Redirect(ReturnUrl);
					}
					else
					{
						ViewBag.UserEmail = TryToSignUser.Email;
						return RedirectToAction("Index", "Employee");
					}
				}
			}

			return View(signIn);
		}

		public IActionResult ForgetPassword()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError(string.Empty, "Problems Here");
				return View(model);
			}

			var user = await _userManager.FindByEmailAsync(model.Email);

			if (user != null)
			{
				var token = await _userManager.GeneratePasswordResetTokenAsync(user);

				var passURL = Url.Action("ResetPassword", "Account", new { email = model.Email, token }, Request.Scheme);
				var emailInfo = new Email
				{
					To = model.Email,
					Subject = "Reset Password",
					Body = passURL
				};
				_emailSettings.SendEmail(emailInfo);
				return RedirectToAction("EmailSentDone");
			}

			ModelState.AddModelError(string.Empty, "This Email Does not Exist!");
			return View(model);
		}

		public IActionResult EmailSentDone()
		{
			return View();
		}

		public IActionResult ResetPassword(string email, string token)
		{
			TempData["Email"] = email;
			TempData["Token"] = token;

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Invalid Password");
				return View();
			}

			var email = TempData["Email"] as string;
			var token = TempData["Token"] as string;

			if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(token))
			{
				var user = await _userManager.FindByEmailAsync(email);

				if (user != null)
				{
					var ChangePassword = await _userManager.ResetPasswordAsync(user, token,viewModel.NewPassword);

					if (ChangePassword.Succeeded)
					{
						return RedirectToAction("SignIn");
					}
                    foreach (var item in ChangePassword.Errors)
                    {
						ModelState.AddModelError("", item.Description);
                    }
					return View();
                }
			}

			return RedirectToAction("IssueOnResetPassword");

		}

		public IActionResult IssueOnResetPassword()
		{
			return View();
		}

		public async new Task<IActionResult> SignOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Department");
		}
	}
}
