using System;

namespace InterviewTest
{
    using Nancy;
    using Nancy.ModelBinding;

    public sealed class TeacherModule : NancyModule
    {
        protected class PutBody
        {
            public PutBody()
            {
            }

            public Guid StudentId { get; set; }
        }

        public TeacherModule(TeacherCollection teacherList, StudentCollection studentList) : base("/teachers")
        {
            Get("/", args => Response.AsJson(teacherList.GetTeachers()));
            Post("/", _ =>
            {
                var teacher = this.Bind<Teacher>();
                teacherList.AddTeacher(teacher);
                return HttpStatusCode.Created;
            });
            Put("/{teacherId}", args =>
            {
                var putBody = this.Bind<PutBody>();
                Guid teacherId = args.teacherId;
                var teacherToUpdate = teacherList.GetTeacherById(teacherId);
                var studentToAdd = studentList.GetStudentById(putBody.StudentId);
                teacherToUpdate.AddStudent(studentToAdd);
                return Response.AsJson(teacherToUpdate);
            });
        }
    }
}