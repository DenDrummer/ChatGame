namespace ChatGame.BL.Domain
{
    public abstract class Enemy : Character
    {
        public Emoji Emoji { get; set; }
        public Streamer Streamer { get; set; }
    }
}