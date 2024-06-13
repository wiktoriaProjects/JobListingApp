namespace JobListingApp.Dto
{
    public class CreateListingDto
    {
        public string Tit { get; set; }
        public string Location  { get; set; }
        public string Desc { get; set; }
        public string Company { get; set; }
        public DateTime PostedDate { get; set; }

        //public int CategoryId { get; set; }
    }
}
