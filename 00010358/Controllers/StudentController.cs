using _00010358.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _00010358.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository) 
        {
            _studentRepository = studentRepository; 
        }

        // GET: api/Student
        [HttpGet]
        public IActionResult Get()
        {
            var stu = _studentRepository.GetStudents();
            return new OkObjectResult(stu);
        }

        // GET: api/Student/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var product = _studentRepository.GeyById(id);
            return new OkObjectResult(product);
        }

        // POST: api/Student 
        [HttpPost] 
        public IActionResult Post([FromBody] Student student) 
        { 
            using (var scope = new TransactionScope()) 
            { 
                _studentRepository.Insert(student); 
                scope.Complete(); 
                return CreatedAtAction(nameof(Get), new { id = student.StudentID }, student);
            } 
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]         
        public IActionResult Put(int id, [FromBody]Student student)         
        {             
            if (student != null)             
            {                 
                using (var scope = new TransactionScope())                
                {                    
                    _studentRepository.Update(student);                    
                    scope.Complete();                    
                    return new OkResult();                
                }            
            }             
            return new NoContentResult();        
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]         
        public IActionResult Delete(int id)         
        {             
            _studentRepository.Delete(id);             
            return new OkResult();        
        }
    }
}
