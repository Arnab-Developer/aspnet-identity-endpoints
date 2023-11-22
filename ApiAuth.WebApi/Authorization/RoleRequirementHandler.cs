namespace ApiAuth.WebApi.Authorization;

public class RoleRequirementHandler(UserManager<IdentityUser> userManager)
    : AuthorizationHandler<RoleRequirement>
{
    private readonly UserManager<IdentityUser> _userManager = userManager;

    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context, RoleRequirement requirement)
    {
        if (requirement == null ||
            context.User.Identity is null ||
            !context.User.Identity.IsAuthenticated ||
            context.User.Identity.Name is null)
        {
            context.Fail();
            return;
        }

        var user = await _userManager.FindByNameAsync(context.User.Identity.Name);

        if (user is null)
        {
            context.Fail();
            return;
        }

        var roles = await _userManager.GetRolesAsync(user);

        if (!roles.Contains(requirement.RoleName))
        {
            context.Fail();
            return;
        }

        context.Succeed(requirement);
    }
}