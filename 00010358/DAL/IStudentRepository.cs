using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _00010358.DAL
{
    public interface IStudentRepository
    {
        void Insert(Student stu);
        Student GeyById(int id);
        void Update(Student stu);

        void Delete(int id);

        List<Student> GetStudents();
    }
}
