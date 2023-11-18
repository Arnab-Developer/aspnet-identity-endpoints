using Microsoft.EntityFrameworkCore;

namespace ApiAuth.WebApi;

public class StudentContext(DbContextOptions<StudentContext> options)
    : DbContext(options)
{
    public DbSet<Student> Students { get; set; }
}