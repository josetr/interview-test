using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest
{
    public class TeacherCollection
    {
        private Dictionary<string, Teacher> _teachers = new Dictionary<string, Teacher>();

        internal void AddTeacher(Teacher teacher)
        {
            _teachers[teacher.Id] = teacher;
        }

        internal List<Teacher> GetTeachers()
        {
            return _teachers.Values.ToList();
        }

        public Teacher GetTeacherById(string teacherId)
        {
            return _teachers[teacherId];
        }

        public void Clear()
        {
            _teachers = new Dictionary<string, Teacher>();
        }
    }
}