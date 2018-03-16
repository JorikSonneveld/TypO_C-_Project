﻿using System.Data.Entity;
using Typo.Model.Database;

namespace Typo.Model
{
    public class ApplicationDatabase : DbContext
    {
        //Initializing database
        public ApplicationDatabase() : base("TypO")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Word> Words { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<KeyMistake> KeyMistakes { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    }
}