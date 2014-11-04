namespace Shop.Net.Web.ViewModels.Account
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }
    }
}