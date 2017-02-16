using ChatGame.BL.Domain.Properties;
using System.ComponentModel.DataAnnotations;

namespace ChatGame.BL.Domain
{
    public class User
    {
        public ushort Id { get; set; }
        [Required]
        [RegularExpression("^[a-z_0-9]{4,20}$", ErrorMessageResourceName = "InvalidUserName", ErrorMessageResourceType = typeof(Resources))]
        public string UserName { get; set; }
    }
}