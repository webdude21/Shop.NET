namespace Shop.Net.Web.Areas.Profile.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Microsoft.AspNet.Identity;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Model;
    using Shop.Net.Model.Shipping;
    using Shop.Net.Web.Areas.Profile.Models;
    using Shop.Net.Web.Controllers;

    public class ContactInformationController : CustomerController
    {
        public ContactInformationController(IShopData shopData)
            : base(shopData)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Get([DataSourceRequest] DataSourceRequest request)
        {
            var userId = this.User.Identity.GetUserId();

            var addresses =
                this.ShopData.ContactInformations.All()
                    .Where(x => x.CustomerId == userId)
                    .Project()
                    .To<ContactInformationViewModel>();

            return this.Json(addresses.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add(
            [DataSourceRequest] DataSourceRequest request, ContactInformationViewModel contactInformation)
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.ShopData.Users.Find(userId);

            if (contactInformation == null || !this.ModelState.IsValid)
            {
                return this.Json(new[] { contactInformation }.ToDataSourceResult(request, this.ModelState));
            }

            var newInfo = GetNewContactInformation(contactInformation, user);
            user.Adresses.Add(newInfo);
            this.ShopData.SaveChanges();

            return this.Json(new[] { contactInformation }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, ContactInformationViewModel contactInformation)
        {
            this.ShopData.ContactInformations.Find(contactInformation.Id);
            this.TryUpdateModel(contactInformation);

            if (this.ModelState.IsValid)
            {
                this.ShopData.SaveChanges();
            }

            return this.Json(new[] { contactInformation }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, ContactInformationViewModel contactInformation)
        {
            var contact = this.ShopData.ContactInformations.Find(contactInformation.Id);

            this.ShopData.ContactInformations.Delete(contact);
            this.ShopData.SaveChanges();

            return this.Json(new[] { contactInformation }.ToDataSourceResult(request, this.ModelState));
        }

        private static ContactInformation GetNewContactInformation(ContactInformationViewModel contactInformation, ApplicationUser user)
        {
            var newInfo = new ContactInformation
            {
                ContactName = contactInformation.ContactName,
                Address1 = contactInformation.Address1,
                Address2 = contactInformation.Address2,
                City = contactInformation.City,
                Country = contactInformation.Country,
                Company = contactInformation.Company,
                PhoneNumber = contactInformation.PhoneNumber,
                StateProvince = contactInformation.StateProvince,
                ZipCode = contactInformation.StateProvince,
                ContactPerson = contactInformation.ContactPerson,
                Email = contactInformation.ContactPerson,
                FaxNumber = contactInformation.FaxNumber
            };
            return newInfo;
        }
    }
}