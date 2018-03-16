﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Typo.Model
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public bool Official { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}