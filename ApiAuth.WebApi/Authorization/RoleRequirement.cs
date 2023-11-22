namespace ApiAuth.WebApi.Authorization;

public class RoleRequirement(string roleName) : IAuthorizationRequirement
{
    public string RoleName { get; set; } = roleName;
}