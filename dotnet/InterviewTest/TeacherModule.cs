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
                var teacher = teacherList.GetTeacherById(teacherId);
                if (teacher == null)
                    return HttpStatusCode.NotFound;
                return Response.AsJson(teacher.Students);
            });
            Post("/{teacherId}/students", args =>
            {
                var putBody = this.Bind<AddTeacherStudentRequest>();
                Guid teacherId = args.teacherId;
                var teacherToUpdate = teacherList.GetTeacherById(teacherId);
                if (teacherToUpdate == null)
                    return HttpStatusCode.NotFound;
                var studentToAdd = studentList.GetStudentById(putBody.StudentId);
                if (studentToAdd == null)
                    return HttpStatusCode.NotFound;
                teacherToUpdate.AddStudent(studentToAdd);
                return Response.AsJson(teacherToUpdate);
            });
        }
    }
}