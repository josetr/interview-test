namespace InterviewTest
{
    using InterviewTest.Models;
    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Validation;
    using System;

    public sealed class StudentModule : NancyModule
    {
        public StudentModule(StudentCollection studentList) : base("/students")
        {
            Get("/", args =>
            {
                return studentList.GetStudents();
            });
            Post("/", _ =>
            {
                var addStudenRequest = this.BindAndValidate<AddStudentRequest>();
                if (!ModelValidationResult.IsValid)
                    return Negotiate.WithModel(ModelValidationResult).WithStatusCode(HttpStatusCode.BadRequest);
                var teacher = new Student(addStudenRequest.Id, addStudenRequest.Name);
                if (!studentList.AddStudent(teacher))
                    return HttpStatusCode.Conflict;
                return HttpStatusCode.Created;
            });
            Put("/{studentId}", args =>
            {
                var updates = this.BindAndValidate<UpdateStudentRequest>();
                if (!ModelValidationResult.IsValid)
                    return Negotiate.WithModel(ModelValidationResult).WithStatusCode(HttpStatusCode.BadRequest);
                Guid studentId = args.studentId;
                var studentToUpdate = studentList.GetStudentById(studentId);
                if (studentToUpdate == null)
                    return HttpStatusCode.NotFound;
                studentToUpdate.Name = updates.Name;
                return studentToUpdate.ToDto();
            });
        }
    }
}