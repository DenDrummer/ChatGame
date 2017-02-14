using Domain.Properties;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Emoji
    {
        public ushort Id { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z:;><()0-9_]{2,}$", ErrorMessageResourceName = "InvalidEmoji", ErrorMessageResourceType = typeof(Resources))]
        public string EmojiTekst { get; set; }
        public uint Rarity { get; set; }
        public ushort Uses { get; set; }
        public uint TotalUses { get; set; }
    }
}