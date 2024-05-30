﻿namespace JobListingApp.Dto
{
    public class CreateListingDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public DateTime PostedDate { get; set; }
        public string Location { get; set; }
        //public int CategoryId { get; set; }
    }
}