namespace InterviewTest.Models;

using FluentValidation;
using System;

public record AddTeacherStudentRequest
{
    public Guid StudentId { get; init; }
}

public class AddTeacherStudentRequestValidator : AbstractValidator<AddTeacherStudentRequest>
{
    public AddTeacherStudentRequestValidator()
    {
        RuleFor(request => request.StudentId).NotEmpty();
    }
}
