using System;
using System.ComponentModel.DataAnnotations;

namespace TechJobPortal.Models
{
    public enum JobType
    {
        FullTime,
        PartTime,
        Remote,
        Contract
    }

    public class JobListing
    {
        public int Id {get; set;}

        [Required]
        public string? Title {get; set;}

        [Required]
        public string? CompanyName {get; set;}

        public string? Location {get; set;}

        public JobType JobType {get; set;}

        public DateTime PostedDate {get; set;}
    }
}