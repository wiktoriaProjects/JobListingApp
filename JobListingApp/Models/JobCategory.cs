using System.ComponentModel.DataAnnotations;

namespace JobListingApp.Models
{
    public static class JobCategory
    {
        public const string IT = "IT";
        public const string Finance = "Finance";
        public const string Healthcare = "Healthcare";
        public const string Education = "Education";
        public const string Construction = "Construction";

        public static readonly List<string> All = new List<string>
        {
            IT,
            Finance,
            Healthcare,
            Education,
            Construction
        };
    }
}

