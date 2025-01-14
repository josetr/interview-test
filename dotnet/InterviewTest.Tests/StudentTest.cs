namespace InterviewTest.Tests;

public class StudentTest
{
    [Fact]
    public async Task Should_GetAnEmptyListOfStudentsAsync()
    {
        var bootstrapper = new Bootstrapper();
        var browser = new Browser(bootstrapper);

        var result = await browser.Get("/students", with =>
        {
            with.HttpRequest();
            with.Header("Accept", "application/json");
        });

        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.Equal("[]", result.Body.AsString());
    }

    [Fact]
    public async Task Should_GetListOfStudentsAsync()
    {
        var bootstrapper = new Bootstrapper();
        var browser = new Browser(bootstrapper);
        var testStudent = await browser.CreateTestStudentAsync();

        var result = await browser.Get("/students", with =>
        {
            with.HttpRequest();
            with.Header("Accept", "application/json");
        });

        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        var studentList = result.Body.DeserializeJson<Student[]>();
        Assert.Single(studentList, testStudent);
    }

    [Fact]
    public async Task Should_UpdateStudentAsync()
    {
        var bootstrapper = new Bootstrapper();
        var browser = new Browser(bootstrapper);
        var testStudent = await browser.CreateTestStudentAsync();

        var result = await browser.Put($"/students/{testStudent.Id}", with =>
        {
            with.HttpRequest();
            with.Header("Accept", "application/json");
            with.JsonBody(new { Name = "Foo" });
        });

        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        var updatedStudent = result.Body.DeserializeJson<Student>();
        Assert.Equal(updatedStudent.Name, "Foo");
    }

    [Fact]
    public async Task Should_GetListOfStudentsByTeacherAsync()
    {
        var bootstrapper = new Bootstrapper();
        var browser = new Browser(bootstrapper);
        var testStudent = await browser.CreateTestStudentAsync();
        var testTeacher = await browser.CreateTestTeacherAsync();
        await browser.AddStudentToTeacherAsync(testStudent.Id, testTeacher.Id);

        var result = await browser.Get($"/teachers/{testTeacher.Id}/students", with =>
        {
            with.HttpRequest();
            with.Header("Accept", "application/json");
        });

        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        var studentList = result.Body.DeserializeJson<Student[]>();
        Assert.Single(studentList, testStudent);
    }
}
