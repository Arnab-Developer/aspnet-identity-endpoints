namespace ApiAuth.WebApi;

internal class StudentValidator : AbstractValidator<Student>
{
    public StudentValidator()
    {
        RuleFor(s => s.FirstName).NotEmpty().WithMessage("Invalid first name");
        RuleFor(s => s.LastName).NotEmpty().WithMessage("Invalid last name");
    }
}