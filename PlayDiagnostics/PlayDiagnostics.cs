using System;
using System.Diagnostics;

namespace playWeb
{
    public class PlayDiagnostics
    {
        public static void Play()
        {
            PlayDebug();
            PlayEventLog();
        }

        static void PlayEventLog()
        {
            using (var p = Process.Start(new ProcessStartInfo()
            {
                FileName = "ping",
                Arguments = "192.168.199.1",
                RedirectStandardOutput = true
            }))
            {
                var s = p.StandardOutput;
                while (!s.EndOfStream)
                {
                    Console.WriteLine(s.ReadLineAsync().Result);
                }
            }
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