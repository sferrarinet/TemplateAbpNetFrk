using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Abp.Application.Services.Dto;
using Manager.Core.Configuration.MultiTenancy;
using Manager.Core.Configuration.Users;

namespace Manager.Web.Models.Account
{
    public class RegisterViewModel : IValidatableObject
    {
        /// <summary>
        /// Not required for single-tenant applications.
        /// </summary>
        [StringLength(Tenant.MaxTenancyNameLength)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(User.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(User.MaxSurnameLength)]
        public string Surname { get; set; }

        [StringLength(User.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(User.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        [StringLength(User.MaxPlainPasswordLength)]
        public string Password { get; set; }

        public bool IsExternalLogin { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var emailRegex = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            if (!UserName.Equals(EmailAddress) && emailRegex.IsMatch(UserName))
            {
                yield return new ValidationResult("Username cannot be an email address unless it's same with your email address !");
            }

            string name = "pawan";
            if (Name != name)
            {
                //yield return new ValidationResult($"input provided is not {name}",new List<string> { "FirstName" });
                yield return new ValidationResult($"input provided is not {name}", new List<string> { "Name", "Gender" });
            }
        }
    }
}