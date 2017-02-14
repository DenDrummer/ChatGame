using Domain;
using System.Collections.Generic;

namespace DAL
{
    public interface IGameRepository
    {
        #region Create methods
        Emoji CreateEmoji(Emoji emoji);
        Streamer CreateStreamer(Streamer streamer);
        User CreateUser(User user);
        Viewer CreateViewer(Viewer viewer);
        #endregion

        #region Delete methods
        void DeleteEmoji(int id);
        #endregion

        #region Read multiple methods
        IEnumerable<Emoji> ReadEmojis();
        IEnumerable<Viewer> ReadViewers(Streamer streamer);
        IEnumerable<Streamer> ReadStreamers();
        IEnumerable<Character> ReadCharacters();
        #endregion

        #region Read single methods
        Streamer ReadStreamer(int streamerId);
        Streamer ReadStreamerFromViewer(int viewerId);
        Viewer ReadViewer(int viewerId);
        #endregion

        #region Update methods
        void UpdateViewer(Viewer viewer);
        void UpdateEmoji(Emoji emoji);
        void UpdateStreamer(Streamer streamer);
        void UpdateEnemy(Enemy enemy);
        #endregion
    }
}
