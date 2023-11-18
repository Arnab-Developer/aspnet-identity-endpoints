namespace ApiAuth.WebApi.Contexts;

internal class StudentContext(DbContextOptions<StudentContext> options)
    : DbContext(options)
{
    public DbSet<Student> Students { get; set; }
}