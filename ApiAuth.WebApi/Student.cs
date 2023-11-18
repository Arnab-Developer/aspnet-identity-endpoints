namespace ApiAuth.WebApi;

public class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Student()
        : this(0, string.Empty, string.Empty)
    {
    }

    public Student(string firstName, string lastName)
        : this(0, firstName, lastName)
    {
    }

    public Student(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
}