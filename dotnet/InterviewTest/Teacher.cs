using System;
using System.Collections.Generic;

namespace InterviewTest
{
    public class Teacher : Person
    {
        // required for serialization
        // ReSharper disable once UnusedMember.Global
        private Teacher()
        {
        }

        public List<Student> Students { get; set; } = new List<Student>();

        public Teacher(Guid id, string name) : base(id, name)
        {
        }

        public void AddStudent(Student studentToAdd)
        {
            Students.Add(studentToAdd);
        }
    }
}