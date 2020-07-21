using System;
using playCS.PlayParallel;
using playCS.playThreadsWorld;

namespace playCS
{
    class Program
    {
        static void Main2(string[] args)
        {
            Console.WriteLine("Main2!");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // new PlayLambda();
            // new PlayBasicType();
            // ConsoleEnhance.Rainbow();
            // PlayLinq.Play();
            // PlayAdvance.Play();
            // PlayAsyncAwait.Play();
            // CancelParallelLoops.CancelParallelLoops.Play();
            // PlayParallel.PlayParallel.Play();

            // PlayTaskAndParallel.Play();
            // PlayTuple.Play();

            PlayReflection.Play();
        }
    }
}