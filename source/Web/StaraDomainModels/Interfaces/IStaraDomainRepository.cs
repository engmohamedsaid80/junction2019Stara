using StaraDomainModels.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaraDomainModels.Interfaces
{
    public interface IStaraDomainRepository
    {

        List<Project> GetProjetcs();
        List<Worker> GetWorkers();

        List<Task> GetTasks(int id);

        void AddTaskUpdate(TaskUpdate dbEnty);

        void UpdateWorker(Worker w);

    }
}
