namespace InterviewTest.Models;

using System;

public record TeacherDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public RecordList<StudentDto> Students { get; init; }
}