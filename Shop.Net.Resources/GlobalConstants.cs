namespace Shop.Net.Resources
{
    public class GlobalConstants
    {
        public const string ShopName = "PhotoLafka";

        public const string Credits = "Powered by Shop.Net";

        public const string GitHubLink = "https://github.com/webdude21/Shop.NET";

        public const string AdministratorRole = "Administrator";

        public const string EmployeeRole = "Employee";

        public const string CustomerRole = "Customer";

        public const string EmailDomainForShop = "@shop.net";

        public const string DefaultAdminUser = "webdude@webdude.eu";

        public const int ProductsOnHomePage = 6;

        public const string FacebookApiKey = "732252256855726";

        public const string FacebookSecretKey = "77d160c38105d70edb40d0e0263e7c89";

        public const string RobotsIndexFollow = "index, follow";

        public const int ItemsPerPage = 12;

        public const string FriendlyUrlsRegexValidator = @"[\w-]+";

        public const string FriendlyUrlsValidatorErrorMessage =
            "Seo friendly urls must only contain Latin letters, digits, dash and underscore";

        public const string NonNegativeNumbers = "The value must be greater than or equal to 0";

        public const string ProductImagesRelativePath = "/Content/Images/Products/";

        public const string GuidRegEx = @"\b[A-F0-9]{8}(?:-[A-F0-9]{4}){3}-[A-F0-9]{12}\b";

        public const string DateTimeFormat = "{0:MM/dd/yyyy HH:MM:ss}";

        public const string DateFormat = "{0:MM/dd/yyyy}";
    }
}