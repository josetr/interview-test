using System;

namespace InterviewTest
{
    using InterviewTest.Models;
    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Validation;
    using System.Linq;

    public sealed class TeacherModule : NancyModule
    {
        public TeacherModule(TeacherCollection teacherList, StudentCollection studentList) : base("/teachers")
        {
            Get("/", args => teacherList.GetTeachers());
            Post("/", _ =>
            {
                var addTeacherRequest = this.BindAndValidate<AddTeacherRequest>();
                if (!ModelValidationResult.IsValid)
                    return Negotiate.WithModel(ModelValidationResult).WithStatusCode(HttpStatusCode.BadRequest);
                var teacher = new Teacher(addTeacherRequest.Id, addTeacherRequest.Name);
                if (!teacherList.AddTeacher(teacher))
                    return HttpStatusCode.Conflict;
                return HttpStatusCode.Created;
            });
            Get("/{teacherId}/students", args =>
            {
                var studentRequestParams = this.BindAndValidate<GetTeacherStudentsRequest>();
                if (!ModelValidationResult.IsValid)
                    return Negotiate.WithModel(ModelValidationResult).WithStatusCode(HttpStatusCode.BadRequest);
                var teacherId = studentRequestParams.TeacherId;
                var teacher = teacherList.GetTeacherById(teacherId);
                if (teacher == null)
                    return HttpStatusCode.NotFound;
                return teacher.Students.Select(x => x.ToDto());
            });
            Post("/{teacherId}/students", args =>
            {
                var putBody = this.BindAndValidate<AddTeacherStudentRequest>();
                if (!ModelValidationResult.IsValid)
                    return Negotiate.WithModel(ModelValidationResult).WithStatusCode(HttpStatusCode.BadRequest);
                Guid teacherId = args.teacherId;
                var teacherToUpdate = teacherList.GetTeacherById(teacherId);
                if (teacherToUpdate == null)
                    return HttpStatusCode.NotFound;
                var studentToAdd = studentList.GetStudentById(putBody.StudentId);
                if (studentToAdd == null)
                    return HttpStatusCode.NotFound;
                teacherToUpdate.AddStudent(studentToAdd);
                return teacherToUpdate.ToDto();
            });
        }
    }
}