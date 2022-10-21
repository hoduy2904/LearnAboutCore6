using LearnAboutNet6.Models;
using LearnAboutNet6.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace LearnAboutNet6.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        public readonly SignInManager<IdentityUser> signInManager;
        private readonly IMailServices mailServices;
        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IMailServices mailServices)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mailServices = mailServices;
        }

        public IActionResult Index()
        {
            return View(new AuthRequest());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = userManager.Users.FirstOrDefault(x => x.Email.Equals(loginRequest.Username) || x.UserName.Equals(loginRequest.Username) && x.EmailConfirmed == true);
                    if (user == null)
                    {
                        ViewBag.Message = "Account not Found or not active";
                        return View(nameof(Index), (new AuthRequest { LoginRequest = loginRequest }));
                    }
                    var result = await signInManager.PasswordSignInAsync(user.UserName, loginRequest.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect("/");
                    }
                }
                ViewBag.Message = "Please input infomation";
                return View(nameof(Index), (new AuthRequest { LoginRequest = loginRequest }));
            }catch (Exception ex)
            {
                ViewBag.Message=ex.Message;
                return View(nameof(Index), (new AuthRequest { LoginRequest = loginRequest }));

            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (registerRequest.Password.Equals(registerRequest.PasswordRepeat))
                    {
                        var user = new IdentityUser
                        {
                            Email = registerRequest.Email,
                            UserName = registerRequest.Username,
                            EmailConfirmed = false
                        };

                        var result = await userManager.CreateAsync(user, registerRequest.Password);
                        if (result.Succeeded)
                        {
                            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                            var url = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + Url.Action(nameof(ConfirmEmail), "Auth", new { token, email = user.Email });
                            bool isSend = mailServices.SendMail("Register Account", $"<a href='{url}'>Click to active Account</a>", user.Email);
                            ViewBag.MessageRegister = "Please Check Mail";
                            return View(nameof(Index), new AuthRequest());
                        }
                        return View(nameof(Index), (new AuthRequest { RegisterRequest = registerRequest }));
                    }
                }
                return View(nameof(Index), (new AuthRequest { RegisterRequest = registerRequest }));
            }catch (Exception ex)
            {
                ViewBag.MessageRegister=ex.Message;
                return View(nameof(Index), (new AuthRequest { RegisterRequest = registerRequest }));

            }

        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return Redirect("/Auth#Login");
                }
            }
            return CreatedAtAction(nameof(Login), ViewBag.Messeage);
        }

        [HttpPost]
        public async Task<ActionResult> ForgotPassword(string Email)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(Email);
                if (user == null)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View();
                }

                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                var url = HttpContext.Request.Host + Url.Action(nameof(ResetPassword), "Auth", new { token, email = user.Email });
                bool isSend = mailServices.SendMail("Reset Password", $"<a href='{url}'>Click to confirm</a>", user.Email);
                if (isSend)
                {
                    ViewBag.Message = "Please check mail";
                    return View();
                }
            }
            ViewBag.Message = "Something error";
            return View();
        }
        public IActionResult ResetPassword(string token, string email)
        {
            return View(new ResetPasswordRequest { Token = token, Email = email });
        }
        [HttpPost]
        public async Task<ActionResult> ResetPassword(ResetPasswordRequest resetPasswordRequest, [FromBody] string ConfirmPassword)
        {
            if (resetPasswordRequest.Password.Equals(ConfirmPassword))
            {
                var user = await userManager.FindByEmailAsync(resetPasswordRequest.Email);
                if (user == null)
                    return View();
                var resetPassResult = await userManager.ResetPasswordAsync(
                    user
                    , resetPasswordRequest.Token,
                    resetPasswordRequest.Password);

                if (!resetPassResult.Succeeded)
                {
                    ViewBag.Message = "Something error";
                    return View(resetPasswordRequest);
                }
                return Redirect("/Auth#Login");
            }
            ViewBag.Message = "Password not match";
            return View(resetPasswordRequest);
        }

    }
}
