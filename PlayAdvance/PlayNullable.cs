#nullable enable
using System;
using System.Collections.Generic;

namespace playCS
{
    public class PlayNullable
    {
        static void Func(string? a)
        {
        }

        static void Func2(string a)
        {
        }


        static void Basic()
        {
            string? a = null;
            int[]? b = null;

            //NOTE a is null
            Console.WriteLine(a);
            
            //NOTE null safe: ?.
            Console.WriteLine(a?.Length);
            
            //NOTE ?[] null safe
            Console.WriteLine(b?[3]);

            //a ?? throw new Exception();
            //NOTE null switch
            var c = a ?? "a is null";

            //NOTE ??= null assign
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
                Console.WriteLine(l?.Count);
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