using WebApp_MongoDB.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace WebApp_MongoDB.Services
{
    public class StudentService
    {
        private readonly IMongoCollection<Student> _Student;
        public StudentService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("DB"));
            var database = client.GetDatabase("GradeBook");
            _Student = database.GetCollection<Student>("Students");
        }
        public List<Student> GetStudents() => _Student.Find(Student => true).ToList();
        public Student GetStudent(string id) => _Student.Find(student => student.Id == id).FirstOrDefault();
        public Student PostStudent(Student student)
        {
            _Student.InsertOne(student);
            return student;
        }
        public Student PutStudent(string id, Student newStudent)
        {
            //Se envía todo el JSON incluído el Id
            _Student.ReplaceOne(student => student.Id == id, newStudent);
            return newStudent;
        }
        public Student DeleteStudent(string id)
        {
            var student = GetStudent(id);
            if(student == null)
            {
                return null;
            }
            else
            {
                _Student.DeleteOne(student => student.Id == id);
                return student;
            }
        }
    }
}