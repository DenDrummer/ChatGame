using System.ComponentModel.DataAnnotations;

namespace ChatGame.BL.Domain
{
    public class Enemy : Character
    {
        [Required]
        public Emoji Emoji { get; set; }
        [Required]
        public Streamer Streamer { get; set; }
    }
}