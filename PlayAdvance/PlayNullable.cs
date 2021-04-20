#nullable enable
using System;
using System.Collections.Generic;

namespace playCS
{
    public class PlayNullable
    {
        //nullable 有几种静态检查方案(在 project 或 file 中设置):
        // * disabled 
        // * enabled: annotation + warn
        // * annotation only: 只检查 x? 这类的null风险
        // * warn only: 只检查 x 这类的 null 风险,而不能使用 x?
        static void Basic()
        {
            string? a = null;
            int[]? b = null;

            Console.WriteLine(a);

            //null safe ops
            Console.WriteLine(a?.Length);
            Console.WriteLine(b?[3]);

            //null assign
            var c = a ?? "a is null";

            c = null;
            c ??= "not null";

            if (c is { })
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