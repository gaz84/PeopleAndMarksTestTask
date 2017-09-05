using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PeopleAndMarksTestTask.Models
{
    public class PeopleDbContext:DbContext
    {
        public PeopleDbContext() : base("PeopleDBContextConString") { }
        public DbSet<Person> People { get; set; }
        public DbSet<Mark> Marks { get; set; }
    }
}