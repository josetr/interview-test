using InterviewTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest
{
    public class StudentCollection
    {
        private Dictionary<Guid, Student> students = new Dictionary<Guid, Student>();

        public void AddStudent(Student student)
        {
            students[student.Id] = student;
        }

        public IEnumerable<Student> GetStudents()
        {
            return students.Values;
        }

        public Student GetStudentById(Guid studentId)
        {
            students.TryGetValue(studentId, out var student);
            return student;
        }

        public void Clear()
        {
            students.Clear();
        }

        public void Update(Student studentToUpdate, UpdateStudentRequest updates)
        {
            students[studentToUpdate.Id].Name = updates.Name;
        }
    }
}