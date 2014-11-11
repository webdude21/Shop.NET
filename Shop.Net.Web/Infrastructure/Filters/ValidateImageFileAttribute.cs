namespace Shop.Net.Web.Infrastructure.Filters
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class ValidateImageFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            const int AllowedMaxSize = 1024 * 1024 * 2;

            var fileBase = value as HttpPostedFileBase;

            if (fileBase == null)
            {
                this.ErrorMessage = @"Please upload a file";
                return false;
            }

            if (fileBase.ContentLength > AllowedMaxSize)
            {
                this.ErrorMessage = string.Format("File size can not exceed {0}", AllowedMaxSize);
                return false;
            }

            var allowedMimeTypes = new List<string> { "image/jpeg", "image/png", "image/gif" };

            if (allowedMimeTypes.Contains(fileBase.ContentType))
            {
                return true;
            }

            this.ErrorMessage = @"File type not supported";
            return false;
        }
    }
}