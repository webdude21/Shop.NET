namespace Shop.Net.Web.Infrastructure.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web;

    using Shop.Net.Model.Catalog;
    using Shop.Net.Resources;
    using Shop.Net.Web.Infrastructure.Contracts;

    public class ImageUploader : IImageUploader
    {
        public void UploadImages(HttpRequestBase request,  HttpServerUtilityBase serverUtility, ICollection<Image> images)
        {
            foreach (string upload in request.Files)
            {
                var httpPostedFileBase = request.Files[upload];
                if (httpPostedFileBase == null || httpPostedFileBase.ContentLength == 0)
                {
                    continue;
                }

                var relativePath = GlobalConstants.ProductImagesRelativePath + DateTime.Now.ToString("dd-MM-yyyy/");
                var pathToSave = serverUtility.MapPath("~" + relativePath);

                this.MakeDirectoryIfNeeded(pathToSave);

                var fileBase = request.Files[upload];

                if (fileBase == null)
                {
                    continue;
                }

                var originalFileName = Path.GetFileName(fileBase.FileName);
                var resultFileName = Guid.NewGuid() + "_" + originalFileName;
                var fileTosave = new Image
                                     {
                                         FileName = originalFileName,
                                         Url = relativePath + resultFileName,
                                         MimeType = fileBase.ContentType
                                     };

                images.Add(fileTosave);
                var postedFileBase = fileBase;
                postedFileBase.SaveAs(Path.Combine(pathToSave, resultFileName));
            }
        }

        private void MakeDirectoryIfNeeded(string pathToSave)
        {
            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }
        }
    }
}