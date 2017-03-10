using System;

namespace ChatGame.BL.Domain
{
    public class Viewer
    {
        public ushort Id { get; set; }
        //the user this viewer represents
        public User User { get; set; }
        //who this user is viewing
        public Streamer Streamer { get; set; }
        //goes up as they chat more
        public double ChatLevel { get; set; }
        //when they were added or their last message was sent
        //(whatever came last)
        public DateTime LastMessage { get; set; }
    }
}