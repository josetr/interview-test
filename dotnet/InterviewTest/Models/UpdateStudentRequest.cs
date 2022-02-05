namespace InterviewTest.Models
{
    using FluentValidation;

    public class UpdateStudentRequest
    {
        public string Name { get; set; }
    }

    public class UpdateStudentRequestValidator : AbstractValidator<UpdateStudentRequest>
    {
        public UpdateStudentRequestValidator()
        {
            RuleFor(request => request.Name).NotEmpty();
        }
    }
}