namespace InterviewTest.Models;

using FluentValidation;
using System;

public record AddTeacherRequest
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}

public class AddTeacherRequestValidator : AbstractValidator<AddTeacherRequest>
{
    public AddTeacherRequestValidator()
    {
        RuleFor(request => request.Id).NotEmpty();
        RuleFor(request => request.Name).NotEmpty();
    }
}
