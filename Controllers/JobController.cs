using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TechJobPortal.Controllers
{
    public class JobController : Controller
    {
        private static readonly List<JobListing> JobListings = new()
        {
            new JobListing { Id = 1, Title = "UI/UX Designer", CompanyName = "Google", Location = "Jeddah", JobType = JobType.FullTime, PostedDate = DateTime.Now },
            new JobListing { Id = 2, Title = "Web Developer", CompanyName = "Elm", Location = "Riyadh", JobType = JobType.FullTime, PostedDate = DateTime.Now },
            new JobListing { Id = 3, Title = "Data Analyst", CompanyName = "Apple", Location = "Chicago", JobType = JobType.Remote, PostedDate = DateTime.Now },
            new JobListing { Id = 4, Title = "Cyber Security", CompanyName = "Amazon", Location = "New York", JobType = JobType.PartTime, PostedDate = DateTime.Now },
            new JobListing { Id = 5, Title = "System Analyst ", CompanyName = "Coursera", Location = "AL Madinah", JobType = JobType.Contract, PostedDate = DateTime.Now }
        };


        public IActionResult Index()
        {
            return View(JobListings);
        }

        public IActionResult Details(int id)
        {
            var job = JobListings.FirstOrDefault(j => j.Id == id);
            if (job == null) return NotFound();

            ViewBag.JobTypeList = Enum.GetValues(typeof(JobType))
                                      .Cast<JobType>()
                                      .Select(jt => new SelectListItem { Value = jt.ToString(), Text = jt.ToString() })
                                      .ToList();

            return View(job);
        }
    }
}
