﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreDemo.Models;
using Microsoft.AspNetCore.Authorization;

namespace EFCoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CoursesController : ControllerBase
    {
        private readonly ContosoUniversityContext _context;
        private readonly ILogger<CoursesController> logger;

        public CoursesController(ContosoUniversityContext context,
            ILogger<CoursesController> logger)
        {
            _context = context;
            this.logger = logger;
        }

        // GET: api/Courses
        /// <summary>
        /// 取得所有課程資料
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet("", Name = nameof(GetCourseAllAsync))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourseAllAsync()
        {
            if (_context.Course == null)
            {
                return NotFound();
            }

            if (User.IsInRole("Admin"))
            {
                // 這裡只有 Admin 可以進來執行
            }

            return Ok(await _context.Course.ToListAsync());
        }

        // GET: api/Courses/5
        /// <summary>
        /// 取得課程資料 By Id
        /// </summary>
        /// <param name="id">課程編號</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("{id}", Name = nameof(GetCourseByIdAsync))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Course>> GetCourseByIdAsync(int id)
        {
            if (_context.Course == null)
            {
                return NotFound();
            }

            logger.LogTrace("取得 CourseId 為 {id} 的資料", id);
            logger.LogDebug("取得 CourseId 為 {id} 的資料", id);
            logger.LogInformation("取得 CourseId 為 {id} 的資料", id);
            logger.LogWarning("取得 CourseId 為 {id} 的資料", id);
            logger.LogError("取得 CourseId 為 {id} 的資料", id);
            logger.LogCritical("取得 CourseId 為 {id} 的資料", id);

            var course = await _context.Course.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}", Name = nameof(PutCourseAsync))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutCourseAsync(int id, Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost(Name = nameof(PostCourseAsync))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Course>> PostCourseAsync(Course course)
        {
            if (_context.Course == null)
            {
                return Problem("Entity set 'ContosoUniversityContext.Course'  is null.");
            }
            _context.Course.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtRoute(nameof(GetCourseAllAsync), new { id = course.CourseId }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}", Name = nameof(DeleteCourseByIdAsync))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteCourseByIdAsync(int id)
        {
            if (_context.Course == null)
            {
                return NotFound();
            }
            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Course.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return (_context.Course?.Any(e => e.CourseId == id)).GetValueOrDefault();
        }
    }
}
