﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EFCoreDemo.Models
{
    public partial class Course : IValidatableObject
    {
        public Course()
        {
            Enrollment = new HashSet<Enrollment>();
            Instructor = new HashSet<Person>();
        }

        public int CourseId { get; set; }

        [Required(ErrorMessage = "請輸入課程名稱")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "請輸入課程評價")]
        [Range(1, 5, ErrorMessage = "課程評價請設定 1 ~ 5")]
        public int Credits { get; set; }
        
        public int DepartmentId { get; set; }

        [JsonIgnore]
        public virtual Department Department { get; set; }
        [JsonIgnore]
        public virtual ICollection<Enrollment> Enrollment { get; set; }

        [JsonIgnore]
        public virtual ICollection<Person> Instructor { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Title.Contains("CECI") && this.Credits < 3)
            {
                yield return new ValidationResult("課程名稱在 Credit 小於 3 的時候不允許出現 CECI 字樣",
                    new string[] { "Title" });
            }
        }
    }
}