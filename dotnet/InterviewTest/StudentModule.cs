namespace InterviewTest
{
    using InterviewTest.Models;
    using Nancy;
    using Nancy.ModelBinding;
    using System;

    public sealed class StudentModule : NancyModule
    {
        public StudentModule(TeacherCollection teacherList, StudentCollection studentList) : base("/students")
        {
            Get("/", args =>
            {
                var studentRequestParams = this.Bind<GetTeacherStudentsRequest>();
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
                var updates = this.Bind<UpdateStudentRequest>();
                Guid studentId = args.studentId;
                var studentToUpdate = studentList.GetStudentById(studentId);
                studentList.Update(studentToUpdate, updates);
                return Response.AsJson(studentToUpdate);
            });
        }
    }
}