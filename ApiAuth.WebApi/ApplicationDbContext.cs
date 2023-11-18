using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ApiAuth.WebApi;

internal class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<IdentityUser>(options)
{
}