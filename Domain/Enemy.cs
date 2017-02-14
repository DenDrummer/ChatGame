namespace Domain
{
    public abstract class Enemy : Character
    {
        public uint Id { get; set; }
        public Emoji Emoji { get; set; }
    }
}