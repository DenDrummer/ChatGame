﻿using ChatGame.BL.Domain;
using System.Collections.Generic;

namespace ChatGame.DAL
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
        void DeleteEmoji(ushort id);
        void DeleteEnemy(uint id);
        #endregion

        #region Read multiple methods
        IEnumerable<Character> ReadCharacters();
        IEnumerable<Emoji> ReadEmojis();
        IEnumerable<Enemy> ReadEnemies();
        IEnumerable<Streamer> ReadStreamers();
        IEnumerable<Viewer> ReadViewers(Streamer streamer);
        #endregion

        #region Read single methods
        Streamer ReadStreamer(int streamerId);
        Streamer ReadStreamerFromViewer(int viewerId);
        Viewer ReadViewer(int viewerId);
        #endregion

        #region Update methods
        void UpdateEmoji(Emoji emoji);
        void UpdateEnemy(Enemy enemy);
        void UpdateStreamer(Streamer streamer);
        void UpdateViewer(Viewer viewer);
        #endregion
    }
}
