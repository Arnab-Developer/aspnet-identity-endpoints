namespace ApiAuth.WebApi;

internal class StudentContext(DbContextOptions<StudentContext> options)
    : DbContext(options)
{
    public DbSet<Student> Students { get; set; }
}