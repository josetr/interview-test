const initialState = {
  teachers: [],
  students: [],
};

function rootReducer(state = initialState, action) {
  switch (action.type) {
    case "ADD_TEACHER":
      state.teachers.push(action.payload);
      break;
    case "ADD_STUDENT":
      state.students.push(action.payload);
      break;
    case "UPDATE_STUDENT":
      for (const s in state.students) {
        if (state.students[s].id === action.payload.id) {
          state.students[s] = action.payload;
          break;
        }
      }
      break;
    case "ASSIGN_STUDENT_TO_TEACHER":
      for (const t in state.teachers)
        if (state.teachers[t].id === action.payload.teacherId) {
          state.teachers[t].students.push(action.payload.studentId)
          break;
        }
      break;
    default:
      break;
  }

  return state;
}

export default rootReducer;