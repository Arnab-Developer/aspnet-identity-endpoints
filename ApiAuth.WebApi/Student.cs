namespace ApiAuth.WebApi;

public class Student(int id, string firstName, string lastName)
{
    public int Id { get; set; } = id;

    public string FirstName { get; set; } = firstName;

    public string LastName { get; set; } = lastName;

    public Student()
        : this(0, string.Empty, string.Empty)
    {
    }

    public Student(string firstName, string lastName)
        : this(0, firstName, lastName)
    {
    }
}