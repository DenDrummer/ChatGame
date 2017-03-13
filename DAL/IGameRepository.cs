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
        void DeleteEmoji(int id);
        void DeleteEnemy(int id);
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
        Emoji ReadEmoji(int emojiId);
        Enemy ReadEnemy(int enemyId);
        Streamer ReadStreamer(int streamerId);
        Streamer ReadStreamerFromViewer(int viewerId);
        User ReadUser(int userId);
        Viewer ReadViewer(int viewerId);
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
