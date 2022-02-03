const initialState = {
  teachers: [],
  students: [],
};

function rootReducer(state = initialState, action) {
  switch (action.type) {
    case "ADD_TEACHER":
      return { ...state, teachers: [...state.teachers, action.payload] };
    case "ADD_STUDENT":
      return { ...state, students: [...state.students, action.payload] };
    case "UPDATE_STUDENT":
      return {
        ...state, students: state.students.map(student => {
          if (student.id === action.payload.id)
            return action.payload;
          return student;
        })
      }
    case "ASSIGN_STUDENT_TO_TEACHER":
      return {
        ...state, teachers: state.teachers.map(teacher => {
          if (teacher.id === action.payload.teacherId)
            return {...teacher, students: [...teacher.students, action.payload.studentId]};
          return teacher;
        })
      }
    default:
      return state;
  }
}

export default rootReducer;