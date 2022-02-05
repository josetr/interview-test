namespace InterviewTest.Models;

using FluentValidation;
using System;

public class AddStudentRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class AddStudentRequestValidator : AbstractValidator<AddStudentRequest>
{
    public AddStudentRequestValidator()
    {
        RuleFor(request => request.Id).NotEmpty();
        RuleFor(request => request.Name).NotEmpty();
    }
}
