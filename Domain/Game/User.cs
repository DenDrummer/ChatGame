using System.ComponentModel.DataAnnotations;

namespace ChatGame.BL.Domain
{
    public class User
    {
        public ushort Id { get; set; }
        [Required]
        [RegularExpression("^[a-z_0-9]{4,25}$", ErrorMessageResourceName = "InvalidUserName", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
    }
}