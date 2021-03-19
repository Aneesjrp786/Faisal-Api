using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dotnet.Models {
    public class Context : DbContext {
        public Context (DbContextOptions<Context> options) : base (options) {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Mcqs> Mcqss { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentQuiz> StudentQuizs { get; set; }

        // public DbSet<UserAuthentication> UserAuthentication { get; set; }
        protected override void OnModelCreating (ModelBuilder modelBuilder) {

          
        }
    }
}