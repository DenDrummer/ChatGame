using ChatGame.BL.Domain;
using System.Collections.Generic;
using System;

namespace ChatGame.DAL
{
    class GameRepositoryHC : IGameRepository
    {
        #region Lists
        private List<Emoji> emojis;
        private List<Enemy> enemies;
        private List<Streamer> streamers;
        private List<User> users;
        private List<Viewer> viewers;
        #endregion

        public GameRepositoryHC()
        {
            Seed();
        }

        private void Seed()
        {
            #region Initialize lists
            emojis = new List<Emoji>();
            enemies = new List<Enemy>();
            streamers = new List<Streamer>();
            users = new List<User>();
            viewers = new List<Viewer>();
            #endregion

            #region Create emojis
            #region em1
            Emoji em1 = new Emoji()
            {
                Id = (ushort)(emojis.Count + 1),
                EmojiTekst = "Kappa",
                Rarity = 1,
                TotalUses = 0,
                Uses = 0
            };
            emojis.Add(em1);
            #endregion

            #region em2
            Emoji em2 = new Emoji()
            {
                Id = (ushort)(emojis.Count + 1),
                EmojiTekst = "PJSalt",
                Rarity = 1,
                TotalUses = 0,
                Uses = 0
            };
            emojis.Add(em2);
            #endregion

            #endregion

            #region Create users
            #endregion

            #region Create streamers
            #endregion

            #region Create viewers
            #endregion
        }

        #region 'IGameRepository' implementation
        #region Create Methods
        public Emoji CreateEmoji(Emoji emoji)
        {
            throw new NotImplementedException();
        }

        public Streamer CreateStreamer(Streamer streamer)
        {
            throw new NotImplementedException();
        }

        public User CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Viewer CreateViewer(Viewer viewer)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Delete methods
        public void DeleteEmoji(ushort id)
        {
            throw new NotImplementedException();
        }

        public void DeleteEnemy(uint id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read multiple methods
        public IEnumerable<Character> ReadCharacters()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Emoji> ReadEmojis()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Enemy> ReadEnemies()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Streamer> ReadStreamers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Viewer> ReadViewers(Streamer streamer)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read single methods
        public Streamer ReadStreamer(int streamerId)
        {
            throw new NotImplementedException();
        }

        public Streamer ReadStreamerFromViewer(int viewerId)
        {
            throw new NotImplementedException();
        }

        public Viewer ReadViewer(int viewerId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update methods
        public void UpdateEmoji(Emoji emoji)
        {
            throw new NotImplementedException();
        }

        public void UpdateEnemy(Enemy enemy)
        {
            throw new NotImplementedException();
        }

        public void UpdateStreamer(Streamer streamer)
        {
            throw new NotImplementedException();
        }

        public void UpdateViewer(Viewer viewer)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
