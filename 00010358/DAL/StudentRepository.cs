using _00010358.DBContext;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _00010358.DAL
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DatabaseContext _dbContext;

        public StudentRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(int id)
        {
            var stu = _dbContext.Student.Find(id);
            _dbContext.Student.Remove(stu);
            Save();
        }
        public Student GeyById(int id)        {
            var stu = _dbContext.Student.Find(id);
            //_dbContext.Entry(stu).Reference(s => s.StudentID).Load();
            return stu;
        }

        public List<Student> GetStudents()
        {
            return _dbContext.Student.ToList();
        }



        public void Insert(Student stu)
        {
            _dbContext.Add(stu);
            Save();
        }

        public void Update(Student stu)
        {
            _dbContext.Entry(stu).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
