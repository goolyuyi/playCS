using System;
using System.Collections.Generic;

namespace playCS
{
    #region Method Extension

    enum MusicStyle
    {
        Techno,
        House,
        Trance,
        Folk,
        Gothic
    }

    static class MusicStyleExt
    {
        //ext by put 'this' first
        public static bool isElectricMusic(this MusicStyle style)
        {
            return (style == MusicStyle.Techno || style == MusicStyle.House || style == MusicStyle.Trance);
        }
    }

    #endregion

    public static class PlayMethodExtension
    {
        public static void Play()
        {
            //扩展方法
            var s = MusicStyle.Techno;
            Console.WriteLine($"{s} is electric?:{s.isElectricMusic()}");
        }
    }
}