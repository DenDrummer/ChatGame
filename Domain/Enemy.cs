namespace ChatGame.BL.Domain
{
    public abstract class Enemy : Character
    {
        public ushort Id { get; set; }
        public Emoji Emoji { get; set; }
        public Streamer Streamer { get; set; }
    }
}