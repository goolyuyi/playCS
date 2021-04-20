using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace playCS
{
    public class PlayLazy
    {
        public static void Play()
        {
            var lazy = new Lazy<IEnumerable<string>>(() => new List<string>() {"a", "zz", "ef"});

            //NOTE actually created
            Debug.Assert(lazy.IsValueCreated == false);
            Console.WriteLine(string.Join(",", lazy.Value));
            Debug.Assert(lazy.IsValueCreated);
        }
    }
}