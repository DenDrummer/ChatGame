using System;

namespace ChatGame.BL.Domain
{
    public class Viewer
    {
        public ushort Id { get; set; }
        public User User { get; set; }
        public Streamer Streamer { get; set; }
        //goes up as they chat more
        public double ChatLevel { get; set; }
        public DateTime LastMessage { get; set; }
    }
}