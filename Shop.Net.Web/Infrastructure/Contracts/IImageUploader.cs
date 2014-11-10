namespace Shop.Net.Web.Infrastructure.Contracts
{
    using System.Collections.Generic;
    using System.Web;

    using Shop.Net.Model.Catalog;

    public interface IImageUploader
    {
        void UploadImages(HttpRequestBase request, HttpServerUtilityBase serverUtility, ICollection<Image> images);

        void DeleteImagesFromFileSystem(List<Image> imagesToDelete, HttpServerUtilityBase server);
    }
}