using ChatGame.BL.Domain;
using System.Collections.Generic;
using System;
using System.Drawing;

namespace ChatGame.DAL
{
    public class GameRepositoryHC : IGameRepository
    {
        #region Lists
        private List<Emoji> emojis;
        private List<Enemy> enemies;
        private List<Streamer> streamers;
        private List<User> users;
        private List<Viewer> viewers;
        #endregion

        #region IDs
        private uint emojiId;
        private uint enemyId;
        private uint streamerId;
        private uint userId;
        private uint viewerId;
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

            #region Initialize IDs
            #endregion

            #region Create emojis
            #region imGlitch
            Emoji imGlitch = NewEmoji("imGlitch", Resources.TwitchResources.img_imGlitch);
            emojis.Add(imGlitch);
            #endregion
            #region Kappa
            Emoji Kappa = NewEmoji("Kappa", Resources.TwitchResources.img_Kappa);
            emojis.Add(Kappa);
            #endregion
            #region PJSalt
            Emoji PJSalt = NewEmoji("PJSalt", Resources.TwitchResources.img_PJSalt);
            emojis.Add(PJSalt);
            #endregion
            #endregion

            #region Create users
            #region Den_drummer
            User u_den_drummer = new User()
            {
                Id = (ushort)(users.Count + 1),
                UserName = "den_drummer",
                IsAdmin = true
            };
            users.Add(u_den_drummer);
            #endregion

            #region DoomCE
            User u_doomce = new User()
            {
                Id = (ushort)(users.Count + 1),
                UserName = "doomce",
                IsAdmin = false
            };
            users.Add(u_doomce);
            #endregion

            #region Jakeo232
            User u_jakeo232 = new User()
            {
                Id = (ushort)(users.Count + 1),
                UserName = "jakeo232",
                IsAdmin = false
            };
            users.Add(u_jakeo232);
            #endregion
            #endregion

            #region Create streamers
            #region Den_drummer
            Streamer s_den_drummer = NewStreamer(u_den_drummer);
            streamers.Add(s_den_drummer);
            #endregion
            #region DoomCE
            Streamer s_doomce = NewStreamer(u_doomce);
            streamers.Add(s_doomce);
            #endregion
            #endregion

            #region Create viewers
            #region Den_drummer's viewers
            #region DoomCE
            Viewer v_dd_d = NewViewer(s_den_drummer, u_doomce);
            viewers.Add(v_dd_d);
            #endregion
            #region Jakeo232
            Viewer v_dd_j = NewViewer(s_den_drummer, u_jakeo232);
            viewers.Add(v_dd_j);
            #endregion
            #endregion

            #region DoomCE's viewers
            #region Den_drummer
            Viewer v_d_dd = NewViewer(s_doomce, u_den_drummer);
            viewers.Add(v_dd_d);
            #endregion
            #region Jakeo232
            Viewer v_d_j = NewViewer(s_doomce, u_jakeo232);
            viewers.Add(v_dd_j);
            #endregion
            #endregion
            #endregion
        }

        #region 'IGameRepository' implementation
        #region Create Methods
        public Emoji CreateEmoji(Emoji emoji)
        {
            emoji.Id = (ushort)(emojis.Count + 1);
            emojis.Add(emoji);

            return emoji;
        }

        public Enemy CreateEnemy(Enemy enemy)
        {
            enemy.Id = (ushort)(enemies.Count + 1);
            enemies.Add(enemy);

            return enemy;
        }

        public Streamer CreateStreamer(Streamer streamer)
        {
            streamer.Id = (ushort)(streamers.Count + 1);
            streamers.Add(streamer);

            return streamer;
        }

        public User CreateUser(User user)
        {
            user.Id = (ushort)(users.Count + 1);
            users.Add(user);

            return user;
        }

        public Viewer CreateViewer(Viewer viewer)
        {
            viewer.Id = (ushort)(viewers.Count + 1);
            viewers.Add(viewer);

            return viewer;
        }
        #endregion

        #region Delete methods
        public void DeleteEmoji(uint id)
        {
            enemies.RemoveAll(e => e.Emoji.Id == id);
            emojis.Remove(ReadEmoji(id));
        }

        public void DeleteEnemy(uint id) => enemies.Remove(ReadEnemy(id));
        #endregion

        #region Read multiple methods
        public IEnumerable<Character> ReadCharacters()
        {
            List<Character> characters = new List<Character>();
            foreach (Streamer s in streamers)
            {
                characters.Add(s);
                foreach (Enemy en in enemies.FindAll(en => en.Streamer.Id == s.Id))
                {
                    characters.Add(en);
                }
            }
            return characters;
        }

        public IEnumerable<Emoji> ReadEmojis() => emojis;

        public IEnumerable<Enemy> ReadEnemies() => enemies;

        public IEnumerable<Streamer> ReadStreamers() => streamers;

        public IEnumerable<User> ReadUsers() => users;

        public IEnumerable<Viewer> ReadViewers() => viewers;
        #endregion

        #region Read single methods
        public Emoji ReadEmoji(uint EmojiId) => emojis.Find(em => em.Id == (ushort)EmojiId);

        public Enemy ReadEnemy(uint EnemyId) => enemies.Find(en => en.Id == (ushort)EnemyId);

        public Streamer ReadStreamer(uint streamerId) => streamers.Find(s => s.Id == streamerId);

        public Streamer ReadStreamerFromViewer(uint viewerId)
        {
            return streamers.Find(s => s.Id == ReadViewer(viewerId).Streamer.Id);
        }

        public User ReadUser(uint userId) => users.Find(u => u.Id == userId);

        public Viewer ReadViewer(uint viewerId) => viewers.Find(v => v.Id == viewerId);
        #endregion

        #region Update methods
        public void UpdateEmoji(Emoji emoji) { }

        public void UpdateEnemy(Enemy enemy) { }

        public void UpdateStreamer(Streamer streamer) { }

        public void UpdateViewer(Viewer viewer) { }
        #endregion

        #region login
        public IEnumerable<string> GetLoginData()
        {
            List<string> loginData = new List<string>()
            {
                "chatgame"//,
                //insert OAuth2 token here
            };
            return loginData;
        }
        #endregion
        #endregion

        #region methods to simplify seed
        private Emoji NewEmoji(string emojiText, Image image)
        {
            return new Emoji()
            {
                Id = (ushort)(emojis.Count + 1),
                EmojiText = emojiText,
                Rarity = 1,
                TotalUses = 0,
                Uses = 0,
                Image = image
            };
        }

        private Streamer NewStreamer(User user)
        {
            return new Streamer()
            {
                Id = (uint)(streamers.Count + 1),
                User = user,

                #region location
                XLocation = 0,
                YLocation = 0,
                #endregion

                #region stats
                Armor = 20,
                AttackSpeed = 2.5,
                Defense = 10,
                Health = 100,
                Level = 0,
                MaxHealth = 100,
                Speed = 3.4,
                Strength = 21,
                #endregion

                #region other
                Money = 0
                #endregion
            };
        }

        private Viewer NewViewer(Streamer streamer, User viewer)
        {
            return new Viewer()
            {
                Id = (ushort)(viewers.Count + 1),
                ChatLevel = 0,
                LastMessage = DateTime.Now.ToUniversalTime(),
                Streamer = streamer,
                User = viewer
            };
        }
        #endregion
    }
}
