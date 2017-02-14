using Domain;
using System.Collections.Generic;

namespace DAL
{
    public interface IUserManager
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

        #region Read methods
        IEnumerable<Emoji> ReadEmojis();
        IEnumerable<Viewer> ReadViewers(Streamer streamer);
        #endregion

        #region Update methods
        #endregion
    }
}
