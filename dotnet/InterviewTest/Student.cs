namespace InterviewTest;

using System;

public class Student : Person
{
    private Student() { }
    public Student(Guid id, string name) : base(id, name) { }
}
