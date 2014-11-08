namespace Shop.Net.Web.Models.Marketing
{
    using Shop.Net.Model.Marketing;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class SeoViewModel : IMapFrom<Seo>
    {
        public string FriendlyUrl { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeyWords { get; set; }
    }
}