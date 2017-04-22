using System;
using System.Collections.Generic;
using System.Linq;
using ChatGame.BL.Domain;
using ChatGame.DAL;
using ChatGame.Resources;
using System.ComponentModel.DataAnnotations;

namespace ChatGame.BL
{
    public class GameManager : IGameManager
    {
        private readonly IGameRepository repo;

        public GameManager()
        {
            repo = new GameRepositoryHC();
        }

        #region Add methods
        #region Add from item methods
        public Emoji AddEmoji(Emoji emoji)
        {
            ValidateEmoji(emoji);
            return repo.CreateEmoji(emoji);
        }

        public Enemy AddEnemy(Enemy enemy)
        {
            ValidateEnemy(enemy);
            return repo.CreateEnemy(enemy);
        }

        public Streamer AddStreamer(Streamer streamer)
        {
            ValidateStreamer(streamer);
            return repo.CreateStreamer(streamer);
        }

        public User AddUser(User user)
        {
            ValidateUser(user);
            return repo.CreateUser(user);
        }

        public Viewer AddViewer(Viewer viewer)
        {
            ValidateViewer(viewer);
            return repo.CreateViewer(viewer);
        }
        #endregion

        #region Add from details methods
        //these methods always call the "add from item" variant after creating the item
        public Emoji AddEmoji(string emojiTekst, int rarity)
        {
            return AddEmoji(new Emoji()
            {
                EmojiText = emojiTekst,
                Rarity = (ushort)rarity,
                Uses = 0,
                TotalUses = 0
            });
        }

        public Enemy AddEnemy(string emojiTekst, string streamerName)
        {
            Emoji em = GetEmoji(emojiTekst);
            Streamer s = GetStreamer(streamerName);
            double statBase = s.Id * em.Id / 10;
            return AddEnemy(new Enemy()
            {
                Emoji = em,
                Streamer = s,
                AttackSpeed = statBase,
                Armor = statBase * 1.1,
                Defense = statBase * 1.2,
                Health = statBase * 100
            });
        }

        public Streamer AddStreamer(string streamerName)
        {
            Streamer streamer = GetStreamer(streamerName);
            if (streamer != null)
            {
                throw new Exception(ExtensionMethods.GetResourceKey(Resources.Resources.ExistingStreamer));
            }
            else
            {
                User user = GetUser(streamerName);
                if (user != null)
                {
                    return CreateDefaultStreamer(user);
                }
                else
                {
                    user = AddUser(streamerName);
                    return CreateDefaultStreamer(user);
                }
            }
        }

        public User AddUser(string userName)
        {
            User user = GetUser(userName);
            if (user != null)
            {
                throw new Exception(ExtensionMethods.GetResourceKey(Resources.Resources.ExistingUser));
            }
            else
            {
                return AddUser(new User()
                {
                    UserName = userName,
                    IsAdmin = false
                });
            }
        }

        public Viewer AddViewer(string viewerName, string streamerName)
        {
            Streamer streamer = GetStreamer(streamerName);
            if (streamer != null)
            {
                return AddViewer(viewerName, streamer);
            }
            else
            {
                return AddViewer(viewerName, AddStreamer(streamerName));
            }
        }

        public Viewer AddViewer(string viewerName, Streamer streamer)
        {
            Viewer viewer = GetViewer(viewerName, streamer);
            if (viewer != null)
            {
                throw new Exception(ExtensionMethods.GetResourceKey(Resources.Resources.ExistingViewer));
            }
            else if (GetStreamer(streamer.Id) == null)
            {
                throw new Exception(ExtensionMethods.GetResourceKey(Resources.Resources.UnregisteredStreamer));
            }
            else
            {
                User user = GetUser(viewerName);
                if (user != null)
                {
                    user = AddUser(viewerName);
                }
                return repo.CreateViewer(new Viewer()
                {
                    User = user,
                    ChatLevel = 0,
                    LastMessage = DateTime.Now,
                    Streamer = streamer
                });
            }
        }
        #endregion
        #endregion

        #region Change methods
        public void ChangeEmoji(Emoji emoji)
        {
            throw new NotImplementedException();
        }

        public void ChangeEnemy(Enemy enemy)
        {
            throw new NotImplementedException();
        }

        public void ChangeStreamer(Streamer streamer)
        {
            throw new NotImplementedException();
        }

        public void ChangeUserName(uint id, string newName)
        {
            throw new NotImplementedException();
        }

        public void ChangeViewer(Viewer viewer)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Get multiple methods
        public IEnumerable<Enemy> GetEnemies()
        {
            return repo.ReadEnemies();
        }

        public IEnumerable<Enemy> GetEnemiesOfStreamer(uint streamerId)
        {
            return GetEnemies()
                .ToList()
                .Where(en => en.Streamer.Id.Equals(streamerId));
        }

        public IEnumerable<Enemy> GetEnemiesWithEmoji(string emojiTekst)
        {
            return GetEnemies()
                .ToList()
                .Where(en => en.Emoji.EmojiText.Equals(emojiTekst));
        }

        public IEnumerable<Emoji> GetEmojis()
        {
            return repo.ReadEmojis();
        }

        public IEnumerable<Streamer> GetStreamers()
        {
            return repo.ReadStreamers();
        }

        public IEnumerable<User> GetUsers()
        {
            return repo.ReadUsers();
        }

        public IEnumerable<Viewer> GetViewers()
        {
            return repo.ReadViewers();
        }

        public IEnumerable<Viewer> GetViewersOfStreamer(Streamer streamer)
        {
            return GetViewers()
                .ToList()
                .Where(v => v.Streamer.Equals(streamer));
        }

        public IEnumerable<Viewer> GetViewersOfStreamer(uint streamerId)
        {
            return GetViewersOfStreamer(GetStreamer(streamerId));
        }
        #endregion

        #region Get single methods
        #region Get by id
        public Enemy GetEnemy(uint enemyId)
        {
            return repo.ReadEnemy(enemyId);
        }

        public Streamer GetStreamer(uint streamerId)
        {
            return repo.ReadStreamer(streamerId);
        }

        public User GetUser(uint userId)
        {
            return repo.ReadUser(userId);
        }

        public Viewer GetViewer(uint viewerId)
        {
            return repo.ReadViewer(viewerId);
        }
        #endregion

        #region Get by details
        public Emoji GetEmoji(string emojiTekst)
        {
            //throw new Exception(ExtensionMethods.GetResourceKey(Resources.Resources.UnkownEmoji));
            return GetEmojis()
                .ToList()
                .Find(em => em.EmojiText.Equals(emojiTekst));
        }

        public Streamer GetStreamer(string streamerName)
        {
            Streamer streamer = GetStreamers()
                .ToList()
                .Find(s => s.User.UserName.Equals(streamerName));
            if (streamer != null)
            {
                return streamer;
            }
            else
            {
                throw new Exception(ExtensionMethods.GetResourceKey(Resources.Resources.UnregisteredStreamer));
            }
        }

        public User GetUser(string userName)
        {
            User user = GetUsers()
                .ToList()
                .Find(u => u.UserName.Equals(userName));
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new Exception(ExtensionMethods.GetResourceKey(Resources.Resources.UnregisteredUser));
            }
        }

        public Viewer GetViewer(string viewerName, string streamerName)
        {
            return GetViewer(viewerName, GetStreamer(streamerName));
        }

        public Viewer GetViewer(string viewerName, Streamer streamer)
        {
            Viewer viewer = GetViewersOfStreamer(streamer)
                .ToList()
                .Find(v => v.User.UserName.Equals(viewerName));
            if (viewer != null)
            {
                return viewer;
            }
            else
            {
                throw new Exception(ExtensionMethods.GetResourceKey(Resources.Resources.UnregisteredViewerOfStreamer));
            }
        }
        #endregion
        #endregion

        #region Remove methods
        public void RemoveEmoji(uint emojiId)
        {
            repo.DeleteEmoji(emojiId);
        }

        public void RemoveEnemy(uint enemyId)
        {
            repo.DeleteEnemy(enemyId);
        }

        public void RemoveStreamer(uint streamerId)
        {
            repo.DeleteStreamer(streamerId);
        }

        public void RemoveUser(uint userId)
        {
            repo.DeleteUser(userId);
        }

        public void RemoveViewer(uint viewerId)
        {
            repo.DeleteViewer(viewerId);
        }
        #endregion

        #region Validate methods
        private void ValidateEmoji(Emoji emoji)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(emoji, new ValidationContext(emoji), errors, validateAllProperties: true);

            if (!valid)
                throw new ValidationException(ExtensionMethods.GetResourceKey(Resources.Resources.InvalidEmoji));
        }

        private void ValidateEnemy(Enemy enemy)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(enemy, new ValidationContext(enemy), errors, validateAllProperties: true);

            if (!valid)
                throw new ValidationException(ExtensionMethods.GetResourceKey(Resources.Resources.InvalidEnemy));
        }

        private void ValidateStreamer(Streamer streamer)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(streamer, new ValidationContext(streamer), errors, validateAllProperties: true);

            if (!valid)
                throw new ValidationException(ExtensionMethods.GetResourceKey(Resources.Resources.InvalidStreamer));
        }

        private void ValidateUser(User user)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(user, new ValidationContext(user), errors, validateAllProperties: true);

            if (!valid)
            {
                throw new ValidationException(ExtensionMethods.GetResourceKey(Resources.Resources.InvalidUserName));
            }
        }

        private void ValidateViewer(Viewer viewer)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(viewer, new ValidationContext(viewer), errors, validateAllProperties: true);

            if (!valid)
                throw new ValidationException(ExtensionMethods.GetResourceKey(Resources.Resources.InvalidViewer));
        }
        #endregion

        #region other
        private Streamer CreateDefaultStreamer(User user)
        {
            return AddStreamer(new Streamer()
            {
                User = user,
                Armor = 0,
                AttackSpeed = 1,
                Defense = 0,
                Health = 1,
                Level = 0,
                MaxHealth = 1,
                Money = 0,
                Speed = 1,
                Strength = 1,
                XLocation = 0,
                YLocation = 0,
            });
        }

        public void SetAdmin(User user, User issuer)
        {
            if (issuer.IsAdmin)
            {
                user.IsAdmin = true;
            }
            else
            {
                throw new Exception(ExtensionMethods.GetResourceKey(Resources.Resources.NonAdminError));
            }
        }
        #endregion
    }
}
