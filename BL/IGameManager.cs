using ChatGame.BL.Domain;
using System.Collections.Generic;

namespace ChatGame.BL
{
    public interface IGameManager
    {
        #region Add methods
        Emoji AddEmoji(string emojiTekst, int rarity);
        Emoji AddEmoji(Emoji emoji);
        Enemy AddEnemy(string emojiTekst, string streamerName);
        Enemy AddEnemy(Enemy enemy);
        Streamer AddStreamer(string streamerName);
        Streamer AddStreamer(Streamer streamer);
        User AddUser(string userName);
        User AddUser(User user);
        Viewer AddViewer(string viewerName, string streamerName);
        Viewer AddViewer(Viewer viewer);
        #endregion

        #region Change methods
        void ChangeEmoji(Emoji emoji);
        void ChangeEnemy(Enemy enemy);
        void ChangeStreamer(Streamer streamer);
        void ChangeUserName(uint id, string newName);
        void ChangeViewer(Viewer viewer);
        #endregion

        #region Get multiple methods
        IEnumerable<Emoji> GetEmojis();
        IEnumerable<Enemy> GetEnemiesOfStreamer(uint streamerId);
        IEnumerable<Enemy> GetEnemiesWithEmoji(string emojiTekst);
        IEnumerable<Streamer> GetStreamers();
        IEnumerable<User> GetUsers();
        IEnumerable<Viewer> GetViewersOfStreamer(uint streamerId);
        #endregion

        #region Get single methods
        Emoji GetEmoji(string emojiTekst);
        Enemy GetEnemy(uint enemyId);
        Streamer GetStreamer(uint streamerId);
        Streamer GetStreamer(string streamerName);
        User GetUser(uint userId);
        User GetUser(string userName);
        Viewer GetViewer(uint viewerId);
        Viewer GetViewer(string viewerName, Streamer streamer);
        #endregion

        #region Remove methods
        void RemoveEmoji(uint emojiId);
        void RemoveEnemy(uint enemyId);
        void RemoveStreamer(uint streamerId);
        void RemoveUser(uint userId);
        void RemoveViewer(uint viewerId);
        #endregion
    }
}
