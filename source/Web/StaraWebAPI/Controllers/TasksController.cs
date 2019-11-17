using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaraDomainModels.Interfaces;
using StaraDomainModels.Model;
using StaraWebAPI.Model;

namespace StaraWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        IStaraDomainRepository _repo;

        public TasksController(IStaraDomainRepository repo)
        {
            _repo = repo;
        }

        // GET api/Tasks/5
        [HttpGet("{id}")]
        public List<StaraDomainModels.Model.Task> Get(int id)
        {

            try
            {
                List<StaraDomainModels.Model.Task> dbworkerss = _repo.GetTasks(id).ToList();
                return dbworkerss;

                //return "value";
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        public string Post(TaskUpdateModel model)
        {

            TaskUpdate tu = new TaskUpdate();

            tu.task_Id = model.taskId;
            tu.worker_id = model.workerid;
            tu.Status = model.Status;
            tu.Description = model.comments;
            _repo.AddTaskUpdate(tu);

            Worker w = new Worker();
            w.WorkerId = int.Parse(model.workerid);
            w.Latitude = model.wLatitude;
            w.Longitude = model.wLongitude;
            _repo.UpdateWorker( w);

            return "OK";
        }
    }
}