﻿namespace JobSeekerAPI.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;

        public ICollection<HR> HRs { get; set; }
    }
}