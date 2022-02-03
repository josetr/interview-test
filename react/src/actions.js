export function addTeacher(teacher) {
  return { type: "ADD_TEACHER", payload: teacher }
}
export function addStudent(student) {
  return { type: "ADD_STUDENT", payload: student }
}
export function updateStudent(payload) {
  return { type: "UPDATE_STUDENT", payload }
}
export function assignStudentToTeacher(payload) {
  return { type: "ASSIGN_STUDENT_TO_TEACHER", payload }
}
