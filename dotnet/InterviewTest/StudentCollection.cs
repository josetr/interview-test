using InterviewTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest
{
    public class StudentCollection
    {
        private Dictionary<Guid, Student> students = new Dictionary<Guid, Student>();

        public bool AddStudent(Student student)
        {
            return students.TryAdd(student.Id, student);
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
    }
}