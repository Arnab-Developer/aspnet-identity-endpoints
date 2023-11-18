namespace ApiAuth.WebApp.Models;

public record class Student
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("firstName")]
    [DisplayName("First Name")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    [DisplayName("Last Name")]
    public string LastName { get; set; }

    public Student()
        : this(0, string.Empty, string.Empty)
    {
    }

    public Student(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
}