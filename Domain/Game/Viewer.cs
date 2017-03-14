using System;
using System.ComponentModel.DataAnnotations;

namespace ChatGame.BL.Domain
{
    public class Viewer
    {
        public uint Id { get; set; }
        //the user this viewer represents
        [Required]
        public User User { get; set; }
        //who this user is viewing
        [Required]
        public Streamer Streamer { get; set; }
        //goes up as they chat more
        public double ChatLevel { get; set; }
        //when they were added or their last message was sent
        //(whatever came last)
        public DateTime LastMessage { get; set; }
    }
}