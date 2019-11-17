using Microsoft.EntityFrameworkCore;
using StaraDomainModels.Interfaces;
using StaraDomainModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaraDomainModels.Concrete
{
    public class StaraDomainRepository : IStaraDomainRepository
    {

        private StaraDM _context;

        public StaraDomainRepository(StaraDM context)
        {
            _context = context;
        }

        public StaraDomainRepository() { }


        public List<Project> GetProjetcs()
        {
            try
            {
                var project = _context.Projects.ToList();
                return project;
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public List<Worker> GetWorkers()
        {
            try
            {
                var workers = _context.Workers.ToList();
                return workers;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public List<Task> GetTasks(int id)
        {
            try
            {
                var tasks = _context.Tasks.Where(c => c.Worker.WorkerId == id && c.Status != "Completed").ToList();
                return tasks;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddTaskUpdate(TaskUpdate dbEnty)
        {
            var taskEntry = _context.Tasks.Where(t => t.TaskId == int.Parse(dbEnty.task_Id)).FirstOrDefault();

            if (taskEntry.Status == "Started")
            {
                taskEntry.StartDate = DateTime.Now;
            }
            else if (taskEntry.Status == "Completed")
            {
                taskEntry.EndTime = DateTime.Now;

                taskEntry.Duration += (taskEntry.EndTime - taskEntry.StartDate).Hours;
            }
            else if (taskEntry.Status == "Paused")
            {
                taskEntry.EndTime = DateTime.Now;

                taskEntry.Duration += (taskEntry.EndTime - taskEntry.StartDate).Hours;
            }
            else if (taskEntry.Status == "Resumed")
            {
                taskEntry.StartDate = DateTime.Now;
            }
                taskEntry.Status = dbEnty.Status;
            taskEntry.TaskId = int.Parse(dbEnty.task_Id);
            _context.TaskUpdates.Add(dbEnty);

            _context.SaveChanges();
        }

        public void UpdateWorker(Worker w)
        {
            Worker dbEntry = _context.Workers.Find(w.WorkerId);

            if (dbEntry != null)
            {
                dbEntry.Latitude = w.Latitude;
                dbEntry.Longitude = w.Longitude;

                _context.SaveChanges();
            }
        }
    }
}
