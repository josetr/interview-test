namespace InterviewTest.Models
{
    using FluentValidation;
    using System;

    public class GetTeacherStudentsRequest
    {
        public Guid TeacherId { get; set; }
    }

    public class GetTeacherStudentsRequestValidator : AbstractValidator<GetTeacherStudentsRequest>
    {
        public GetTeacherStudentsRequestValidator()
        {
            RuleFor(request => request.TeacherId).NotEmpty();
        }
    }
}