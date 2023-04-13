using EFCoreDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C2Controller : ControllerBase
    {
        private readonly ContosoUniversityContext context;

        public C2Controller(ContosoUniversityContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IEnumerable<Course> Get(string? name)
        {
            var data = context.Course.AsQueryable();
            if (!String.IsNullOrEmpty(name))
            {
                data = data.Where(p => p.Title.Contains(name));
            }
            //return data.OrderBy(p => p.CourseId).Skip(10).Take(10);
            return data;
        }

        [HttpGet("{id}")]
        public ActionResult<Course> GetById(int id)
        {
            var data = context.Course.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            return data;
        }

        [HttpPost]
        public ActionResult<Course> Create(Course course)
        {
            context.Course.Add(course);
            context.SaveChanges();

            return CreatedAtAction(nameof(GetById), 
                new { id = course.CourseId }, course);
        }
    }
}
