namespace InterviewTest.Models;

using FluentValidation;
using System;

public record GetTeacherStudentsRequest
{
    public Guid TeacherId { get; init; }
}

public class GetTeacherStudentsRequestValidator : AbstractValidator<GetTeacherStudentsRequest>
{
    public GetTeacherStudentsRequestValidator()
    {
        RuleFor(request => request.TeacherId).NotEmpty();
    }
}
