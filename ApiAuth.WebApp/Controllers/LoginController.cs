namespace ApiAuth.WebApp.Controllers;

public class LoginController(SignInManager<IdentityUser> signInManager) : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager = signInManager;

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
}