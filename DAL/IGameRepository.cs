using ChatGame.BL.Domain;
using System.Collections.Generic;

namespace ChatGame.DAL
{
    public interface IGameRepository
    {
        #region Create methods
        Emoji CreateEmoji(Emoji emoji);
        Enemy CreateEnemy(Enemy enemy);
        Streamer CreateStreamer(Streamer streamer);
        User CreateUser(User user);
        Viewer CreateViewer(Viewer viewer);
        #endregion

        #region Delete methods
        void DeleteEmoji(uint id);
        void DeleteEnemy(uint id);
        #endregion

        #region Read multiple methods
        IEnumerable<Character> ReadCharacters();
        IEnumerable<Emoji> ReadEmojis();
        IEnumerable<Enemy> ReadEnemies();
        IEnumerable<Streamer> ReadStreamers();
        IEnumerable<User> ReadUsers();
        IEnumerable<Viewer> ReadViewers();
        #endregion

        #region Read single methods
        Emoji ReadEmoji(uint emojiId);
        Enemy ReadEnemy(uint enemyId);
        Streamer ReadStreamer(uint streamerId);
        Streamer ReadStreamerFromViewer(uint viewerId);
        User ReadUser(uint userId);
        Viewer ReadViewer(uint viewerId);
        #endregion

        #region Update methods
        void UpdateEmoji(Emoji emoji);
        void UpdateEnemy(Enemy enemy);
        void UpdateStreamer(Streamer streamer);
        void UpdateViewer(Viewer viewer);
        #endregion

        #region login
        IEnumerable<string> GetLoginData();
        #endregion
    }
}
