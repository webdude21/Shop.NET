namespace Shop.Net.Web.Models
{
    public class PagerViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public string TargetUrl { get; set; }
    }
}