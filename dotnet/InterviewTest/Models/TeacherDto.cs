namespace InterviewTest.Models;

using System;
using System.Collections.Generic;

public class TeacherDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Student> Students { get; set; }
}
