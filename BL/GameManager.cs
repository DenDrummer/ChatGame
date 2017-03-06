using System;
using System.Collections.Generic;
using System.Linq;
using ChatGame.BL.Domain;
using ChatGame.DAL;
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
        #endregion

        #region Add from details methods
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
                throw new Exception(Resources.Resources.StreamerExists);
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
                    AddUser(streamerName);
                    throw new NotImplementedException();
                }
            }
        }
        #endregion
        #endregion

        #region Change methods
        #endregion

        #region Get multiple methods
        #endregion

        #region Get single methods
        public Streamer GetStreamer(string streamerName)
        {
            return repo.ReadStreamers()
                .ToList()
                .Find(s => s.User.UserName.Equals(streamerName));
        }

        public User GetUser(string userName)
        {
            return repo.ReadUsers()
                .ToList()
                .Find(u => u.UserName.Equals(userName));
        }
        #endregion

        #region Remove methods
        #endregion

        #region Validate methods
        private void ValidateEmoji(Emoji emoji)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(emoji, new ValidationContext(emoji), errors, validateAllProperties: true);

            if (!valid)
                throw new ValidationException(Resources.Resources.InvalidEmoji);
        }

        private void ValidateEnemy(Enemy enemy)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(enemy, new ValidationContext(enemy), errors, validateAllProperties: true);

            if (!valid)
                throw new ValidationException(Resources.Resources.InvalidEnemy);
        }
        #endregion

        private void ValidateStreamer(Streamer streamer)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(streamer, new ValidationContext(streamer), errors, validateAllProperties: true);

            if (!valid)
                throw new ValidationException(Resources.Resources.InvalidStreamer);
        }

        public Viewer AddViewer(Viewer viewer)
        {
            throw new NotImplementedException();
        }

        public Viewer AddViewer(string userName, string streamerName)
        {
            throw new NotImplementedException();
        }

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

        public void ChangeUserName(ushort id, string newName)
        {
            throw new NotImplementedException();
        }

        public void ChangeViewer(Viewer viewer)
        {
            throw new NotImplementedException();
        }

        public Emoji GetEmoji(string emojiTekst)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Emoji> GetEmojis()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Enemy> GetEnemiesOfStreamer(int streamerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Enemy> GetEnemiesWithEmoji(string emojiTekst)
        {
            throw new NotImplementedException();
        }

        public Enemy GetEnemy(int enemyId)
        {
            throw new NotImplementedException();
        }

        public Streamer GetStreamer(int streamerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Streamer> GetStreamers()
        {
            throw new NotImplementedException();
        }

        public User GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Viewer GetViewer(int viewerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Viewer> GetViewersOfStreamer(int streamerId)
        {
            throw new NotImplementedException();
        }

        public void RemoveEmoji(int emojiId)
        {
            throw new NotImplementedException();
        }

        public void RemoveEnemy(int enemyId)
        {
            throw new NotImplementedException();
        }

        public void RemoveStreamer(int streamerId)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(int userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveViewer(int viewerId)
        {
            throw new NotImplementedException();
        }

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

        public User AddUser(string userName)
        {
            throw new NotImplementedException();
        }

        public User AddUser(User user)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
