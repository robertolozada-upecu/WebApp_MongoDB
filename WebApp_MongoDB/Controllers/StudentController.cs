using WebApp_MongoDB.Models;
using WebApp_MongoDB.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApp_MongoDB.Controller
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController
    {
        private readonly StudentService _studentService;
        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public ActionResult<List<Student>> GetStudents() => _studentService.GetStudents();
        [HttpGet("{id:length(24)}")]
        public ActionResult<Student> GetStudent(string id) => _studentService.GetStudent(id);
        [HttpPost]
        public ActionResult<Student> PostStudent(Student student) => _studentService.PostStudent(student);
        [HttpPut("{id:length(24)}")]
        public ActionResult<Student> PutStudent(string id, Student student) => _studentService.PutStudent(id, student);
        [HttpDelete("{id:length(24)}")]
        public ActionResult<Student> DeleteStudents(string id) => _studentService.DeleteStudent(id);

    }
}
