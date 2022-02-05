using System;

namespace InterviewTest
{
    using InterviewTest.Models;
    using Nancy;
    using Nancy.ModelBinding;

    public sealed class TeacherModule : NancyModule
    {
        public TeacherModule(TeacherCollection teacherList, StudentCollection studentList) : base("/teachers")
        {
            Get("/", args => Response.AsJson(teacherList.GetTeachers()));
            Post("/", _ =>
            {
                var teacher = this.Bind<Teacher>();
                teacherList.AddTeacher(teacher);
                return HttpStatusCode.Created;
            });
            Get("/{teacherId}/students", args =>
            {
                var studentRequestParams = this.Bind<GetTeacherStudentsRequest>();
                var teacherId = studentRequestParams.TeacherId;
                return Response.AsJson(teacherList.GetTeacherById(teacherId).Students);
            });
            Post("/{teacherId}/students", args =>
            {
                var putBody = this.Bind<AddTeacherStudentRequest>();
                Guid teacherId = args.teacherId;
                var teacherToUpdate = teacherList.GetTeacherById(teacherId);
                var studentToAdd = studentList.GetStudentById(putBody.StudentId);
                teacherToUpdate.AddStudent(studentToAdd);
                return Response.AsJson(teacherToUpdate);
            });
        }
    }
}