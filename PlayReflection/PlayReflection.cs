using System;
using System.Reflection;

namespace playCS
{
    public class PlayReflection
    {
        public static void Play()
        {
            PlayAssembly();
        }

        static void PlayAssembly()
        {
            var cur = Assembly.GetCallingAssembly();   
            Console.WriteLine(cur.Location);
            Console.WriteLine(cur.Modules);
            var curm = cur.GetModules()[0];
            Console.WriteLine(curm.Name);
            var curts = curm.GetTypes();
            

        }
    }
}