﻿using System;
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

        public Viewer AddViewer(Viewer viewer)
        {
            ValidateViewer(viewer);
            return repo.CreateViewer(viewer);
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
                throw new Exception(Resources.Resources.ExistingStreamer);
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
                throw new Exception(Resources.Resources.ExistingViewer);
            }
            else
            {

                throw new NotImplementedException();
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

        public void ChangeUserName(ushort id, string newName)
        {
            throw new NotImplementedException();
        }

        public void ChangeViewer(Viewer viewer)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Get multiple methods
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

        public IEnumerable<Viewer> GetViewers(Streamer streamer)
        {
            return repo.ReadViewers()
                .ToList()
                .Where(v => v.Streamer.Equals(streamer));
        }
        #endregion

        #region Get single methods
        public Emoji GetEmoji(string emojiTekst)
        {
            return GetEmojis()
                .ToList()
                .Find(em => em.EmojiText.Equals(emojiTekst));
        }

        public Streamer GetStreamer(string streamerName)
        {
            return GetStreamers()
                .ToList()
                .Find(s => s.User.UserName.Equals(streamerName));
        }

        public User GetUser(string userName)
        {
            return GetUsers()
                .ToList()
                .Find(u => u.UserName.Equals(userName));
        }

        public Viewer GetViewer(string viewerName, string streamerName)
        {
            return GetViewer(viewerName, GetStreamer(streamerName));
        }

        public Viewer GetViewer(string viewerName, Streamer streamer)
        {
            return GetViewers(streamer)
                .ToList()
                .Find(v => v.User.UserName.Equals(viewerName));
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

        private void ValidateStreamer(Streamer streamer)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(streamer, new ValidationContext(streamer), errors, validateAllProperties: true);

            if (!valid)
                throw new ValidationException(Resources.Resources.InvalidStreamer);
        }

        private void ValidateViewer(Viewer viewer)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(viewer, new ValidationContext(viewer), errors, validateAllProperties: true);

            if (!valid)
                throw new ValidationException(Resources.Resources.InvalidViewer);
        }
        #endregion

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

        public User GetUser(int userId)
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

        public void SetAdmin(User user, User issuer)
        {
            if (issuer.IsAdmin)
            {
                user.IsAdmin = true;
            }
            else
            {
                throw new Exception($"NonAdminError: {Resources.Resources.NonAdminError}");
            }
        }
        #endregion
    }
}
