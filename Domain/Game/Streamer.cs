using System.ComponentModel.DataAnnotations;

namespace ChatGame.BL.Domain
{
    public class Streamer : Character
    {
        [Required]
        public User User { get; set; }
    }
}