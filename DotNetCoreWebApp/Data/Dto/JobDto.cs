using System;

namespace DotNetCoreWebApp.Data.Dto
{
    public class JobDto
    {
        public int  Id { get; set; }
        public string JobCode { get; set; }
        public string Title { get; set; }
        public string MinimumQualification { get; set; }
        public string SortDescription { get; set; }

        public DateTime LastApplyDate { get; set; }
    }

    


}
