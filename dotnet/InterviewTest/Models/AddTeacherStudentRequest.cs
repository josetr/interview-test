namespace InterviewTest.Models;

using FluentValidation;
using System;

public class AddTeacherStudentRequest
{
    public Guid StudentId { get; set; }
}

public class AddTeacherStudentRequestValidator : AbstractValidator<AddTeacherStudentRequest>
{
    public AddTeacherStudentRequestValidator()
    {
        RuleFor(request => request.StudentId).NotEmpty();
    }
}
