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
        public static bool isElectricMusic(this MusicStyle style)
        {
            return (style == MusicStyle.Techno || style == MusicStyle.House || style == MusicStyle.Trance);
        }
    }

    #endregion

    public static class PlayAdvance
    {
        public static void Play()
        {
            //扩展方法
            var s = MusicStyle.Techno;
            Console.WriteLine($"{s} is electric?:{s.isElectricMusic()}");

            //任意参数
            AtSymbolAndparamsKeyWord(1, 2, 3);
        }

        static void AtSymbolAndparamsKeyWord(params int[] inn)
        {
            foreach (var @ins in inn)
            {
                Console.WriteLine(@ins);
            }
        }
    }
}