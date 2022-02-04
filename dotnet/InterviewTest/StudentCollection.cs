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

        public List<Student> GetStudents()
        {
            return students.Values.ToList();
        }

        public Student GetStudentById(Guid studentId)
        {
            return students[studentId];
        }

        public void Clear()
        {
            students = new Dictionary<Guid, Student>();
        }

        public void Update(Student studentToUpdate, UpdateStudentRequest updates)
        {
            students[studentToUpdate.Id].Name = updates.Name;
        }
    }
}