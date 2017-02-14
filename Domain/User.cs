using Domain.Properties;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class User
    {
        public ushort Id { get; set; }
        [Required]
        [RegularExpression("^[a-z_]{4,12}$", ErrorMessageResourceName = "InvalidUserName", ErrorMessageResourceType = typeof(Resources))]
        public string UserName { get; set; }
    }
}