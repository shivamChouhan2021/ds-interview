using System;

namespace DotNetCoreWebApp.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string JobCode { get; set; }
        public string Title { get; set; }
        public string MinimumQualification { get; set; }
        public string SortDescription { get; set; }
        
        public DateTime LastApplyDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
