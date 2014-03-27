using Voltran.Web.Data.Entities;
using Voltran.Web.Helpers;

namespace Voltran.Web.Models
{
    public class UserModel : BaseModel
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; } 

        public bool IsValidForNewTranslator()
        {
            return !string.IsNullOrEmpty(Name)
                   && Email.IsEmail();
        }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Password)
                   && !string.IsNullOrEmpty(Name)
                   && Email.IsEmail()
                   && IsActive;
        }

        public static UserModel Map(User user)
        {
            var model = new UserModel
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                RoleName = user.RoleName, 
                IsActive = user.IsActive,
                RoleId = user.RoleId
            };
            return model;
        }
    }
}