using System.ComponentModel.DataAnnotations;

namespace ChatGame.BL.Domain
{
    public class User
    {
        public uint Id { get; set; }
        [Required]
        [RegularExpression("^[a-z_0-9]{4,25}$", ErrorMessage = "InvalidUserName")]
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
    }
}