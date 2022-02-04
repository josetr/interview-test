namespace InterviewTest
{
    using System;

    public class Student : Person
    {
        public Student() { }
        public Student(Guid id, string name) : base(id, name) { }
    }
}