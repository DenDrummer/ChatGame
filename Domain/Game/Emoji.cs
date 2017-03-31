using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace ChatGame.BL.Domain
{
    public class Emoji
    {
        public ushort Id { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z:;><()0-9_]{2,}$", ErrorMessage = "InvalidEmoji")]
        public string EmojiText { get; set; }
        //how rare this emoji is considered
        //this dictates how many times it needs to be used before spawning
        //thus the higher the number, the rarer the emoji
        public ushort Rarity { get; set; }
        /**
         * Uses will probably moved to a separate class
         * TotalUses will be copied to said class
         * this class will contain a unique combination of an Emoji and a Streamer
         * this way it will be unique for each Streamer
         */
        //should be reset as soon as it reaches the rarity
        public ushort Uses { get; set; }
        //total ammount this emoji has been used across all streamers
        //mainly for statistical purposes so the weight and rarity can be altered
        //weight: used to determine which emoji to use when multiple are supplied in a single message
        public uint TotalUses { get; set; }
        //the image of the emoji
        public Image Image { get; set; }
    }
}