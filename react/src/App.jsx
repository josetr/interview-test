import React, { Component } from 'react';
import './App.css';
import { connect } from "react-redux";
import { addStudent, addTeacher, assignStudentToTeacher, updateStudent } from './actions';
import uuidv1 from "uuid";

const mapStateToProps = state => {
  return {
    teachers: state.teachers,
    students: state.students,
  };
};

const mapDispatchToProps = dispatch => ({
  addTeacher: teacher => dispatch(addTeacher(teacher)),
  addStudent: student => dispatch(addStudent(student)),
  updateStudent: updates => dispatch(updateStudent(updates)),
  assignStudentToTeacher: (teacherId, studentId) => dispatch(assignStudentToTeacher({ teacherId, studentId }))
});

class ConnectedApp extends Component {
  constructor(props) {
    super(props);
    this.state = {
      newTeacherName: '',
      newStudentName: '',
      updateStudentName: '',
      updatingStudent: null,
      assignStudentTo: null,
    };
  }

  handleNewTeacher = (event) => {
    event.preventDefault();
    const { newTeacherName } = this.state;
    const id = uuidv1();
    this.props.addTeacher({ name: newTeacherName, id, students: [] });
    this.setState({ newTeacherName: "" });
  }

  handleNewStudent = (event) => {
    event.preventDefault();
    const { newStudentName } = this.state;
    const id = uuidv1();
    this.props.addStudent({ name: newStudentName, id });
    this.setState({ newStudentName: "" });
  }

  handleUpdateStudent = (s, name) => {
    const isUpdating = this.state.updatingStudent === s.id;
    if (isUpdating) {
      this.props.updateStudent({ name, id: s.id });
      this.setState({ updatingStudent: null, updateStudentName: '' });
      return;
    }

    this.setState({ updatingStudent: s.id, updateStudentName: s.name });
  }

  handleAssignStudent = (teacherId, studentId) => {
    this.props.assignStudentToTeacher(teacherId, studentId);
    this.setState({ assignStudentTo: null });
  }

  render() {
    let teachers = this.props.teachers;
    let students = this.props.students;

    return (
      <div className="app">
        <div className="teachers">
          <h1>Teachers</h1>
          <table>
            <tbody>
            <tr>
              <td>Id</td>
              <td>Name</td>
              <td>Students</td>
            </tr>
            {teachers.map(teacher => <tr>
              <td>{teacher.id}</td>
              <td>{teacher.name}</td>
              <td>
                <ul>
                  {teacher.students.map(student => <li>{students.map(currentStudent => student === currentStudent.id ? currentStudent.name : '')}</li>)}
                  {this.state.assignStudentTo === teacher.id ?
                    <select onChange={e => this.handleAssignStudent(teacher.id, e.target.value)}>
                      <option selected="selected"></option>
                      {students.map(student => <option value={student.id}>{student.name}</option>)}
                    </select>
                    : null}
                  <button type="button" className="btn"
                          onClick={() => this.setState({ assignStudentTo: teacher.id })}>
                    Assign Student
                  </button>
                </ul>
              </td>
            </tr>)}
            </tbody>
          </table>
          <form onSubmit={this.handleNewTeacher}>
            <div>
              <label>New Teacher</label>
              <input type="text" value={this.state.newTeacherName}
                     onChange={e => this.setState({ newTeacherName: e.target.value })}/>
              <button type="submit" className="btn">
                Add Teacher
              </button>
            </div>
          </form>
        </div>
        <div className="students">
          <h1>Students</h1>
          <table>
            <tbody>
            <tr>
              <td>Id</td>
              <td>Name</td>
              <td></td>
            </tr>
            {students.map(student => <tr>
              <td>{student.id}</td>
              <td>{this.state.updatingStudent === student.id ? <input type="text" value={this.state.updateStudentName}
                                                                onChange={e => this.setState({ updateStudentName: e.target.value })}/> : student.name}</td>
              <td>
                <button type="button" className="btn"
                        onClick={e => this.handleUpdateStudent(student, this.state.updateStudentName)}>
                  {this.state.updatingStudent !== student.id ? "Update Student" : "Done"}
                </button>
              </td>
            </tr>)}
            </tbody>
          </table>
          <form onSubmit={this.handleNewStudent}>
            <div>
              <label>New Student</label>
              <input type="text" value={this.state.newStudentName}
                     onChange={e => this.setState({ newStudentName: e.target.value })}/>
              <button type="submit" className="btn">
                Add Student
              </button>
            </div>
          </form>
        </div>
      </div>
    );
  }
}

const App = connect(mapStateToProps, mapDispatchToProps)(ConnectedApp);

export default App;
