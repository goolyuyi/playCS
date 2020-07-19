using System;
using playCS.playThreadsWorld;

namespace playCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // new PlayLambda();
            // new PlayBasicType();
            // ConsoleEnhance.Rainbow();
            // PlayLinq.Play();
            // PlayAdvance.Play();
            // PlayAsyncAwait.Play();
            CancelParallelLoops.Program.Play();
            // PlayTPL.Play();
        }
    }
}