using ChatGame.BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGame.BL
{
    public interface IGameManager
    {
        #region Add methods
        Emoji AddEmoji(string emojiTekst, int rarity);
        Enemy AddEnemy(string emojiTekst, string streamerName);
        Streamer AddStreamer(string streamerName);
        Viewer AddViewer(string userName, string streamerName);
        #endregion

        #region Change methods
        void ChangeEmoji(Emoji emoji);
        void ChangeEnemy(Enemy enemy);
        void ChangeStreamer(Streamer streamer);
        void ChangeUserName(ushort id, string newName);
        void ChangeViewer(Viewer viewer);
        #endregion

        #region Get multiple methods
        IEnumerable<Emoji> GetEmojis();
        IEnumerable<Enemy> GetEnemiesOfStreamer(int streamerId);
        IEnumerable<Enemy> GetEnemiesWithEmoji(string emojiTekst);
        IEnumerable<Streamer> GetStreamers();
        IEnumerable<User> GetUsers();
        IEnumerable<Viewer> GetViewersOfStreamer(int streamerId);
        #endregion

        #region Get single methods
        Emoji GetEmoji(string emojiTekst);
        Enemy GetEnemy(int enemyId);
        Streamer GetStreamer(int streamerId);
        User GetUser(int userId);
        Viewer GetViewer(int viewerId);
        #endregion

        #region Remove methods
        void RemoveEmoji(int emojiId);
        void RemoveEnemy(int enemyId);
        void RemoveStreamer(int streamerId);
        void RemoveUser(int userId);
        void RemoveViewer(int viewerId);
        #endregion
    }
}
