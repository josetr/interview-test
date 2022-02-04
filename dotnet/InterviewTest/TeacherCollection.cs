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

        public List<Teacher> GetTeachers()
        {
            return _teachers.Values.ToList();
        }

        public Teacher GetTeacherById(Guid teacherId)
        {
            return _teachers[teacherId];
        }

        public void Clear()
        {
            _teachers = new Dictionary<Guid, Teacher>();
        }
    }
}