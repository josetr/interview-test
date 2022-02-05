namespace InterviewTest;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

public class TeacherCollection
{
    private ConcurrentDictionary<Guid, Teacher> _teachers = new ConcurrentDictionary<Guid, Teacher>();

    public bool AddTeacher(Teacher teacher)
    {
        return _teachers.TryAdd(teacher.Id, teacher);
    }

    public IEnumerable<Teacher> GetTeachers()
    {
        return _teachers.Values;
    }

    public Teacher GetTeacherById(Guid teacherId)
    {
        _teachers.TryGetValue(teacherId, out var teacher);
        return teacher;
    }

    public void Clear()
    {
        _teachers.Clear();
    }
}
