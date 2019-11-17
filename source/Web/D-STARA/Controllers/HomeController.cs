using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using D_STARA.Models;
using StaraDomainModels;
using StaraDomainModels.Interfaces;
using StaraDomainModels.Model;

namespace D_STARA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly StaraDM _context;
        private static string _LocationType;
        IStaraDomainRepository _repo;

        public HomeController(IStaraDomainRepository repo)
        {
            //_logger = logger;
            //ILogger<HomeController> logger

            _repo = repo;
        }

        public IActionResult Index()
        {
            var projects = new List<Project>();
            string error = "";
           
            try
            {
                 var dbprojects = _repo.GetProjetcs().ToList();
                return View(dbprojects);

            }
            catch(Exception ex)
            {
                error = ex.Message;
                return View();
            }
           
           
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Workers()
        {
            var projects = new List<Project>();
            string error = "";

            try
            {
                var dbworkerss = _repo.GetWorkers().ToList();
                return View(dbworkerss);

            }
            catch (Exception ex)
            {
                error = ex.Message;
                return View();
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
