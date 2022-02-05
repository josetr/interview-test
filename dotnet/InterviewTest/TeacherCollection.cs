using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest
{
    public class TeacherCollection
    {
        private Dictionary<Guid, Teacher> _teachers = new Dictionary<Guid, Teacher>();

        public void AddTeacher(Teacher teacher)
        {
            _teachers[teacher.Id] = teacher;
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
}