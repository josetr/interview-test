namespace InterviewTest
{
    using Nancy;
    using Nancy.ModelBinding;
    using System;

    public sealed class StudentModule : NancyModule
    {
        public class StudentRequestParams
        {
            public StudentRequestParams()
            {
            }

            public Guid? TeacherId { get; set; }
        }

        public class PutParams
        {
            public PutParams()
            {
            }

            public string Name { get; set; }
        }

        public StudentModule(TeacherCollection teacherList, StudentCollection studentList) : base("/students")
        {
            Get("/", args =>
            {
                var studentRequestParams = this.Bind<StudentRequestParams>();
                var teacherId = studentRequestParams.TeacherId;
                return teacherId != null
                    ? Response.AsJson(teacherList.GetTeacherById(teacherId.Value).Students)
                    : Response.AsJson(studentList.GetStudents());
            });
            Post("/", _ =>
            {
                var student = this.Bind<Student>();
                studentList.AddStudent(student);
                return HttpStatusCode.Created;
            });
            Put("/{studentId}", args =>
            {
                var updates = this.Bind<PutParams>();
                Guid studentId = args.studentId;
                var studentToUpdate = studentList.GetStudentById(studentId);
                studentList.Update(studentToUpdate, updates);
                return Response.AsJson(studentToUpdate);
            });
        }
    }
}