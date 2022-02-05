using System;
using System.Threading.Tasks;
using Nancy;
using Nancy.Testing;
using Xunit;

namespace InterviewTest.Tests
{
    public static class Utils
    {
        private static Guid GuidOne = Guid.NewGuid();

        public static async Task<Student> CreateTestStudentAsync(this Browser browser)
        {
            var testStudent = new Student(GuidOne, "Student");

            var postResult = await browser.Post("/students", with =>
            {
                with.HttpRequest();
                with.JsonBody(testStudent);
            });

            Assert.Equal(HttpStatusCode.Created, postResult.StatusCode);
            return testStudent;
        }

        public static async Task<Teacher> CreateTestTeacherAsync(this Browser browser)
        {
            var testTeacher = new Teacher(GuidOne, "Teacher");

            var postResult = await browser.Post("/teachers", with =>
            {
                with.HttpRequest();
                with.JsonBody(testTeacher);
            });
            
            Assert.Equal(HttpStatusCode.Created, postResult.StatusCode);
            return testTeacher;
        }

        public static async Task AddStudentToTeacherAsync(this Browser browser, Guid studentId, Guid teacherId)
        {
            var putBody = new {studentId};
            var postResult = await browser.Post($"/teachers/{teacherId}/students", with =>
            {
                with.HttpRequest();
                with.JsonBody(putBody);
            });

            Assert.Equal(HttpStatusCode.OK, postResult.StatusCode);
        }
    }
}