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
                return Response.AsJson(studentList.GetStudents());
            });
            Post("/", _ =>
            {
                var student = this.Bind<Student>();
                studentList.AddStudent(student);
                return HttpStatusCode.Created;
            });
            Put("/{studentId}", args =>
            {
                var updates = this.Bind<UpdateStudentRequest>();
                var validationResult = this.Validate(updates);
                if (!validationResult.IsValid)
                    return Negotiate.WithModel(validationResult).WithStatusCode(HttpStatusCode.BadRequest);
                Guid studentId = args.studentId;
                var studentToUpdate = studentList.GetStudentById(studentId);
                if (studentToUpdate == null)
                    return HttpStatusCode.NotFound;
                studentToUpdate.Name = updates.Name;
                return Response.AsJson(studentToUpdate);
            });
        }
    }
}