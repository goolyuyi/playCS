using System;
using System.Diagnostics;

namespace playWeb
{
    public class PlayDiagnostics
    {
        public static void Play()
        {
            PlayDebug();
            //TODO more example
        }

        static void PlayDebug()
        {
            //NOTE Only works in debug mode
            Debug.Write("to Debug Output panel");
            
            Console.Write("to Console panel");

            try
            {
                Debug.Assert(false);
            }
            catch 
            {
                Console.WriteLine("here");
            }

            Debug.Assert(false);
            
            
        }
    }
}