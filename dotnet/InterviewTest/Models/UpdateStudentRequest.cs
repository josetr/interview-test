namespace InterviewTest.Models;

using FluentValidation;

public record UpdateStudentRequest
{
    public string Name { get; init; }
}

public class UpdateStudentRequestValidator : AbstractValidator<UpdateStudentRequest>
{
    public UpdateStudentRequestValidator()
    {
        RuleFor(request => request.Name).NotEmpty();
    }
}
