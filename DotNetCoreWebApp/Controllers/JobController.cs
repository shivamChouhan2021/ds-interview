using DotNetCoreWebApp.Data;
using DotNetCoreWebApp.Data.Dto;
using DotNetCoreWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace DotNetCoreWebApp.Controllers
{
    public class JobController : Controller
    {
        private readonly AppDbContext _context;        
        public JobController(AppDbContext contex)
        { 
            _context = contex;
            
        }
        public async Task<IActionResult> Index()
        {
            var SessionLoginUserId = HttpContext.Session.GetInt32("_LoginUserId");


            if (SessionLoginUserId == null)
            {
                ViewData["Message"] = "Asp.Net Core !!!.";               
                return RedirectToAction("Login", "Account");
            }
            var jobs = await _context.Jobs.Where(us => us.UserId == SessionLoginUserId).ToListAsync();
            return View(jobs);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  Add(JobDto job)
        {
            var SessionLoginUserId = HttpContext.Session.GetInt32("_LoginUserId");
            var result = new Job
            {
                JobCode = job.JobCode,
                Title = job.Title,
                MinimumQualification = job.MinimumQualification,
                SortDescription = job.SortDescription,
                LastApplyDate = job.LastApplyDate,
                UserId = (int)SessionLoginUserId,
            };
            await _context.Jobs.AddAsync(result);   
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Job Successfully Added!...";
            return RedirectToAction("Index");           
        }

        [HttpGet]
        public async Task<IActionResult> View(int Id)
        {
            var SessionLoginUserId = HttpContext.Session.GetInt32("_LoginUserId");
            var result = await _context.Jobs.Where(od => od.Id == Id ).Where(pr => pr.UserId == SessionLoginUserId).FirstOrDefaultAsync();
            var data = new JobDto
            {
                Id = result.Id,
                JobCode = result.JobCode,
                Title= result.Title,
                MinimumQualification= result.MinimumQualification,
                SortDescription= result.SortDescription,
                LastApplyDate= result.LastApplyDate

            };
            return await Task.Run( () => View("View", data));
        }

        [HttpPost]
        public async Task<IActionResult> View(JobDto job)
        {
            var SessionLoginUserId = HttpContext.Session.GetInt32("_LoginUserId");
            var result = await _context.Jobs.Where(od => od.Id == job.Id).Where(pr => pr.UserId == SessionLoginUserId).FirstOrDefaultAsync();
            if (result != null)
            { 
                result.JobCode = job.JobCode;
                result.Title = job.Title;
                result.MinimumQualification = job.MinimumQualification;
                result.SortDescription = job.SortDescription;
                result.LastApplyDate = job.LastApplyDate;
                result.UserId = (int) SessionLoginUserId;

                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Job Successfully Updated!...";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");           
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Job job)
        {
            var SessionLoginUserId = HttpContext.Session.GetInt32("_LoginUserId");
            var result = await _context.Jobs.Where(od => od.Id == job.Id).Where(pr => pr.UserId == SessionLoginUserId).FirstOrDefaultAsync();
            if (result != null)
            {
                _context.Jobs.Remove(result);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Job Successfully Deleted!...";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }














    }
}
