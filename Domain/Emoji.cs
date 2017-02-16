﻿using ChatGame.BL.Domain.Properties;
using System.ComponentModel.DataAnnotations;

namespace ChatGame.BL.Domain
{
    public class Emoji
    {
        public ushort Id { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z:;><()0-9_]{2,}$", ErrorMessageResourceName = "InvalidEmoji", ErrorMessageResourceType = typeof(Resources))]
        public string EmojiTekst { get; set; }
        //how rare this emoji is considered
        //this dictates how many times it needs to be used before spawning
        //thus the higher the number, the rarer the emoji
        public ushort Rarity { get; set; }
        //should be reset as soon as it reaches the rarity
        public ushort Uses { get; set; }
        public uint TotalUses { get; set; }
    }
}