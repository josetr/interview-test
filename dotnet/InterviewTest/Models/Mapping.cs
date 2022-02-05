namespace InterviewTest.Models;

using System.Linq;

public static class Mapping
{
    public static StudentDto ToDto(this Student student)
    {
        return new StudentDto
        {
            Id = student.Id,
            Name = student.Name,
        };
    }

    public static TeacherDto ToDto(this Teacher teacher)
    {
        return new TeacherDto
        {
            Id = teacher.Id,
            Name = teacher.Name,
            Students = teacher.Students.Select(x => x.ToDto()).ToRecordList(),
        };
    }
}
