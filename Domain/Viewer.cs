using System;

namespace Domain
{
    public class Viewer
    {
        public ushort Id { get; set; }
        public User User { get; set; }
        public Streamer Streamer { get; set; }
        public ushort ChatLevel { get; set; }
        public DateTime LastMessage { get; set; }
    }
}