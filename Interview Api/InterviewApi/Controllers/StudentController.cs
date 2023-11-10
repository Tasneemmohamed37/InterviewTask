using InterviewApi.Models;
using InterviewApi.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentRepo _stdRepo;

        //DI -> dependency injection design pattern
        public StudentController(IStudentRepo stdRepo)
        {
            _stdRepo = stdRepo;

        }

        [HttpGet("{id:int}")] //Get /api/Student/1
        public IActionResult GetById(int id)
        {
            Student student = _stdRepo.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            
            return Ok(student);
        }

        [HttpGet("All")] //GET /api/Student/all
        public IActionResult GetAll()
        {
            List<Student> students = _stdRepo.GetAll();
            return Ok(students);
        }

        [HttpPost] //Post /api/Student
        public IActionResult PostNew(Student student)
        {
            if (ModelState.IsValid)
            {
                bool check = _stdRepo.Insert(student);
                if (check)
                {
                    return Ok();
                }
                return BadRequest();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")] //Delete /api/Student/1
        public IActionResult Delete(int id)
        {
            bool check = _stdRepo.Delete(id);
            if (check)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut] //Put /api/Student
        public IActionResult Update(Student student)
        {
            if (ModelState.IsValid)
            {
                bool check = _stdRepo.Update(student);
                if (check)
                {
                    return Ok();
                }
                return BadRequest();
            }
            return BadRequest(ModelState);
        }


    }
}
