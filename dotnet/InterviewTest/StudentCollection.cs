namespace InterviewTest;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

public class StudentCollection
{
    private ConcurrentDictionary<Guid, Student> students = new ConcurrentDictionary<Guid, Student>();

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
