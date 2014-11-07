namespace Shop.Net.Web.Infrastructure.Helpers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public static class HtmlExtensions
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string src, string altText, object attributes = null)
        {
            var image = new TagBuilder("img");
            image.MergeAttribute("src", src);
            image.MergeAttribute("alt", altText);
            var otherAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(attributes) as IDictionary<string, object>;
            image.MergeAttributes(otherAttributes);
            return MvcHtmlString.Create(image.ToString(TagRenderMode.SelfClosing));
        }
    }
}