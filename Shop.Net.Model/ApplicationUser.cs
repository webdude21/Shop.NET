namespace Shop.Net.Model
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Shop.Net.Model.Shipping;

    public class ApplicationUser : IdentityUser
    {
        private ICollection<ContactInformation> adresses;

        public ApplicationUser()
        {
            this.adresses = new HashSet<ContactInformation>();
        }

        public virtual ICollection<ContactInformation> Adresses
        {
            get
            {
                return this.adresses;
            }

            set
            {
                this.adresses = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}