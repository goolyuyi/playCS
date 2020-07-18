using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace playCS.playThreadsWorld
{
    public static class PlayTPL
    {
        public static void Play()
        {
            Sum();
        }

        static void Sum()
        {
            var x = new int[10000 * 10000];

            var rnd = new Random();

            Parallel.For(0, x.Length, (i) => { x[i] = rnd.Next(10); });

            var res = 0;

            var stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            Parallel.For(0, x.Length, (i) =>
            {
                //DON'T wrong caused by racing
                // res += x[i];

                Interlocked.Add(ref res, x[i]);
            });
            stopwatch.Stop();
            Console.WriteLine($"stop:{stopwatch.Elapsed.Milliseconds}");

            stopwatch.Reset();
            stopwatch.Start();
            var resRight = 0;
            foreach (var i in x)
            {
                resRight += i;
            }

            stopwatch.Stop();
            Console.WriteLine($"stop:{stopwatch.Elapsed.Milliseconds}");
            Console.WriteLine(resRight);
            Console.WriteLine(res);
        }
    }
}