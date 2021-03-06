﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.API.Models
{
    public class CourseInstructor
    {
        [Key]
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int InstructorID { get; set; }
        public Course Course { get; set; }
        public Instructor Instructor { get; set; }
    }
}
