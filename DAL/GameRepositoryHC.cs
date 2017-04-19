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
        private ushort emojiId;
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
            emojiId = 1;
            enemyId = 1;
            streamerId = 1;
            userId = 1;
            viewerId = 1;
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
            User u_den_drummer = NewUser("den_drummer");
            users.Add(u_den_drummer);
            #endregion

            #region DoomCE
            User u_doomce = NewUser("doomce");
            users.Add(u_doomce);
            #endregion

            #region Jakeo232
            User u_jakeo232 = NewUser("jakeo232");
            users.Add(u_jakeo232);
            #endregion

            #region LeijonaErvasti
            User u_leijonaervasti = NewUser("leijonaervasti");
            users.Add(u_leijonaervasti);
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

            #region LeijonaErvasti
            Streamer s_leijonaervasti = NewStreamer(u_leijonaervasti);
            streamers.Add(s_leijonaervasti);
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
            emoji.Id = emojiId++;
            emojis.Add(emoji);

            return emoji;
        }

        public Enemy CreateEnemy(Enemy enemy)
        {
            enemy.Id = enemyId++;
            enemies.Add(enemy);

            return enemy;
        }

        public Streamer CreateStreamer(Streamer streamer)
        {
            streamer.Id = streamerId++;
            streamers.Add(streamer);

            return streamer;
        }

        public User CreateUser(User user)
        {
            user.Id = userId++;
            users.Add(user);

            return user;
        }

        public Viewer CreateViewer(Viewer viewer)
        {
            viewer.Id = viewerId++;
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

        public void DeleteStreamer(uint id)
        {
            viewers.RemoveAll(v => v.Streamer.Id == id);
            streamers.Remove(ReadStreamer(id));
        }

        public void DeleteUser(uint id)
        {
            viewers.RemoveAll(v => v.User.Id == id);
            viewers.RemoveAll(v => v.Streamer.User.Id == id);
            streamers.RemoveAll(s => s.User.Id == id);
            users.Remove(ReadUser(id));
        }
        public void DeleteViewer(uint id) => viewers.Remove(ReadViewer(id));
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
                Id = emojiId++,
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
                Id = streamerId++,
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

        private User NewUser(string userName)
        {
            return new User()
            {
                Id = userId++,
                UserName = userName,
                IsAdmin = false
            };
        }

        private Viewer NewViewer(Streamer streamer, User viewer)
        {
            return new Viewer()
            {
                Id = viewerId++,
                ChatLevel = 0,
                LastMessage = DateTime.Now.ToUniversalTime(),
                Streamer = streamer,
                User = viewer
            };
        }
        #endregion
    }
}
