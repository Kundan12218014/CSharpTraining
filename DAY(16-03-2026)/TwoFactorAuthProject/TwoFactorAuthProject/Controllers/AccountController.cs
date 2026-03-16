using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TwoFactorAuthProject.Models;
using TwoFactorAuthProject.Services;
using TwoFactorAuthProject.ViewModels;

namespace TwoFactorAuthProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly QRCodeService _qrService; 
        private readonly EmailSender _emailSender;

        public AccountController(
            SignInManager<ApplicationUser> _signInManger,
            UserManager<ApplicationUser> _userManger,
            QRCodeService qrService,
            EmailSender emailSender) 
        {
            this._signInManager = _signInManger;
            this._userManager = _userManger;
            this._qrService = qrService;
            this._emailSender = emailSender;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register() => View(new LoginViewModel());

        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, EmailConfirmed = true };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    HttpContext.Session.SetString("UserEmail", user.Email ?? string.Empty);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(
                model.Email,
                model.Password,
                model.RememberMe,
                lockoutOnFailure: true);
            if (result.RequiresTwoFactor)
            {
                return RedirectToAction("SendCode", new { rememberMe = model.RememberMe });
            }
            if (result.Succeeded)
            {
                HttpContext.Session.SetString("UserEmail", model.Email);
                return RedirectToAction("Index", "Home");
            }
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Account locked. Try in 15 minutes");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Login Attempt");
            }
            return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> SendCode(bool rememberMe)
        {
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return RedirectToAction("Login");
            }
            var userFactors = await _userManager.GetValidTwoFactorProvidersAsync(user);
            var factorOptions = userFactors.Select(purpose => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = purpose, Value = purpose }).ToList();

            return View(new SendCodeViewModel { Providers = factorOptions, RememberMe = rememberMe });
        }

        [HttpPost]
        public async Task<IActionResult> SendCode(SendCodeViewModel model)
        {
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            if (model.SelectedProvider == "Email")
            {
                var code = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");

                string emailBody = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: auto; padding: 20px; border: 1px solid #e0e0e0; border-radius: 10px; background-color: #ffffff; box-shadow: 0 4px 8px rgba(0,0,0,0.1);'>
                        <h2 style='color: #333; text-align: center; border-bottom: 2px solid #007bff; padding-bottom: 10px;'>Your Verification Code</h2>
                        <p style='font-size: 16px; color: #555;'>Hello,</p>
                        <p style='font-size: 16px; color: #555;'>Please use the verification code below to securely log into your account:</p>
                        <div style='text-align: center; margin: 30px 0;'>
                            <span style='display: inline-block; font-size: 28px; font-weight: bold; color: #007bff; background-color: #f1f8ff; padding: 15px 30px; border-radius: 8px; letter-spacing: 4px; border: 1px dashed #007bff;'>{code}</span>
                        </div>
                        <p style='font-size: 14px; color: #777;'>If you did not request this code, please ignore this email or contact support if you have concerns.</p>
                        <hr style='border: none; border-top: 1px solid #eee; margin: 20px 0;' />
                        <p style='font-size: 12px; color: #aaa; text-align: center;'>&copy; {DateTime.Now.Year} TwoFactorAuthProject. All rights reserved.</p>
                    </div>";

                await _emailSender.SendEmailAsync(user.Email!, "Your 2FA Security Code", emailBody);
            }

            return RedirectToAction("VerifyCode", new { provider = model.SelectedProvider, rememberMe = model.RememberMe });
        }

        [HttpGet]
        public async Task<IActionResult> VerifyCode(string provider, bool rememberMe, string returnUrl = null)
        {
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return RedirectToAction("Login");
            }
            return View(new VerifyCodeViewModel { Provider = provider, RememberMe = rememberMe });
        }

        [HttpPost]
        public async Task<IActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();

            var verificationCode = model.Code?.Replace(" ", string.Empty).Replace("-", string.Empty);

            var result = await _signInManager.TwoFactorSignInAsync(
                model.Provider ?? "Authenticator",
                verificationCode,
                model.RememberMe,
                model.RememberMachine);
            if (result.Succeeded)
            {
                if (user != null)
                {
                    HttpContext.Session.SetString("UserEmail", user.Email ?? string.Empty);
                }
                return RedirectToAction("Index", "Home");

                }
            ModelState.AddModelError("", "Invalid code");
            return View(model);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> SetupAuthenticator()
        {
            var user = await _userManager.GetUserAsync(User);
            var key = await _userManager.GetAuthenticatorKeyAsync(user);
            if (string.IsNullOrEmpty(key))
            {
                await _userManager.ResetAuthenticatorKeyAsync(user);
                key = await _userManager.GetAuthenticatorKeyAsync(user);
            }
            string uri = $"otpauth://totp/MyApp:{user.Email}?secret={key}&issuer=MyApp";
            var qrCode = _qrService.GenerateQRCode(uri);
            ViewBag.QRCode = qrCode;
            ViewBag.Key = key;
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> VerifyAuthenticator(string code)
        {
            var user = await _userManager.GetUserAsync(User);
            var verificationCode = code?.Replace(" ", string.Empty).Replace("-", string.Empty);
            var isValid = await _userManager.VerifyTwoFactorTokenAsync(user, _userManager.Options.Tokens.AuthenticatorTokenProvider, verificationCode);
            if (!isValid)
            {
                ModelState.AddModelError("", "Invalid Code");
                var key = await _userManager.GetAuthenticatorKeyAsync(user);
                string uri = $"otpauth://totp/MyApp:{user?.Email}?secret={key}&issuer=MyApp";
                ViewBag.QRCode = _qrService.GenerateQRCode(uri);
                ViewBag.Key = key;
                return View("SetupAuthenticator");
            }
            await _userManager.SetTwoFactorEnabledAsync(user, true);
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EnableEmail2FA()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                user.EmailConfirmed = true; 
                await _userManager.UpdateAsync(user);
                await _userManager.SetTwoFactorEnabledAsync(user, true);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
