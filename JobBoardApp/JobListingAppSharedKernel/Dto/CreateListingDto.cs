namespace JobListingApp.SharedKernel.Dto
{
    public class CreateListingDto
    {
        public string Tit { get; set; }
        public string Location { get; set; }
        public string Desc { get; set; }
        public string Company { get; set; }
        public DateTime PostedDate { get; set; }
        public string ImageUrl { get; set; } = "/images/no-image-icon.png";

        //public int CategoryId { get; set; }
    }
}
