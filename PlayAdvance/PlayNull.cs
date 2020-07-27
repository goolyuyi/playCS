#nullable enable
using System;
using System.Collections.Generic;

namespace playCS
{
    public class PlayNull
    {
        public static void Func(string? a)
        {
        }

        public static void Func2(string a)
        {
        }

        
        public static void Basic()
        {
            string? a = null;
            int[]? b = null;

            //NOTE a is null
            Console.WriteLine(a);
            //NOTE null safe: ?.
            Console.WriteLine(a?.Length);
            //NOTE ?[]
            Console.WriteLine(b?[3]);

            //NOTE only could value or throw
            //a ?? throw new Exception();
            var c = a ?? "a is null";

            //??=
            c = null;
            c ??= "not null";

            if (c is {})
            {
                Console.WriteLine(c);
            }

            try
            {
                List<string>? l = null;
                //suppress warning
                Console.WriteLine(l!.Count);
            }
            catch
            {
                // ignored
            }
        }

        public static void Play()
        {
            Basic();
        }
    }
}