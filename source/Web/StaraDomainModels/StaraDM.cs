using Microsoft.EntityFrameworkCore;
using StaraDomainModels.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaraDomainModels
{
    public class StaraDM : DbContext
    {

        public StaraDM(DbContextOptions<StaraDM> options)
          : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<feedback> Feedbacks { get; set; }
        public virtual DbSet<Foreman> Foreman { get; set; }
        public virtual DbSet<Hours> Hours { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskUpdate> TaskUpdates { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        public StaraDM()
        {

        }

    }
}
