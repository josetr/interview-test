namespace InterviewTest.Models
{
    using FluentValidation;
    using System;
    using System.Collections.Generic;

    public class AddTeacherRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class AddTeacherRequestValidator : AbstractValidator<AddTeacherRequest>
    {
        public AddTeacherRequestValidator()
        {
            RuleFor(request => request.Id).NotEmpty();
            RuleFor(request => request.Name).NotEmpty();
        }
    }
}