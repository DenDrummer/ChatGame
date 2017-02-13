using Domain.Properties;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    class Emoji
    {
        public ushort Id { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessageResourceName = "InvalidEmoji", ErrorMessageResourceType = typeof(Resources))]
        public string EmojiTekst { get; set; }
    }
}
