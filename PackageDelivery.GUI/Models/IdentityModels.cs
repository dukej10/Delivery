using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PackageDelivery.GUI.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que authenticationType debe coincidir con el valor definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar reclamaciones de usuario personalizadas aquí
            return userIdentity;
        }
    }

    public class DocumentTypeImpApplication : IdentityDbContext<ApplicationUser>
    {
        public DocumentTypeImpApplication()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static DocumentTypeImpApplication Create()
        {
            return new DocumentTypeImpApplication();
        }

        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Parameters.DocumentTypeModel> DocumentTypeModels { get; set; }

        public System.Data.Entity.DbSet<PackageDelivery.Application.Contracts.DTO.DocumentTypeDTO> DocumentTypeDTOes { get; set; }

        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Parameters.PersonModel> PersonModels { get; set; }

        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Parameters.TransportTypeModel> TransportTypeModels { get; set; }

        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Parameters.MunicipalityModel> MunicipalityModels { get; set; }

        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Parameters.DepartmentModel> DepartmentModels { get; set; }
    }
}