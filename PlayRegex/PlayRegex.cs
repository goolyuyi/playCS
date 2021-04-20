using System;
using System.Text.RegularExpressions;

namespace playCS.PlayRegex
{
    public class PlayRegex
    {
        public static void Play()
        {
            var regex = new Regex(@"(?:test)(yes)");
            string test = "testyes\nno";
            Console.WriteLine(test);
            var m = regex.Match(test);
            Console.WriteLine(m);
            
        }
    }
}