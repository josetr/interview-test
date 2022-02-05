namespace InterviewTest.Models;

using FluentValidation;
using System;

public record AddStudentRequest
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}

public class AddStudentRequestValidator : AbstractValidator<AddStudentRequest>
{
    public AddStudentRequestValidator()
    {
        RuleFor(request => request.Id).NotEmpty();
        RuleFor(request => request.Name).NotEmpty();
    }
}
