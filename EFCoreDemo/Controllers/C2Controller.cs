using EFCoreDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var data = context.Course.AsNoTracking().AsQueryable();
            if (!String.IsNullOrEmpty(name))
            {
                data = data.Where(p => p.Title.Contains(name));
            }
            //return data.OrderBy(p => p.CourseId).Skip(10).Take(10);
            return data;
        }

        [HttpGet("v2")]
        public IEnumerable<Course> GetV2(string? name)
        {
            var data = context.Course.AsNoTracking().AsQueryable();
            if (!String.IsNullOrEmpty(name))
            {
                data = data.Where(p => p.Title.Contains(name));
            }
            //return data.OrderBy(p => p.CourseId).Skip(10).Take(10);
            return data;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<Course> GetById(int id)
        {
            var course = context.Course.Find(id);
            if (course == null)
            {
                return NotFound();
            }
            return course;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public ActionResult<Course> Create(Course course)
        {
            context.Course.Add(course);
            context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = course.CourseId }, course);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public ActionResult<Course> Update(int id, Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            var item = context.Course.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            item.Title = course.Title;
            item.Credits = course.Credits;

            //item.UpdatedOn = DateTime.Now;

            context.SaveChanges();

            return Ok(course);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult Delete(int id)
        {
            var item = context.Course.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            context.Course.Remove(item);
            context.SaveChanges();

            return Ok(item);
        }
    }
}
