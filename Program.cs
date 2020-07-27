using System;
using playCS.PlayParallel;
using playCS.playThreadsWorld;

namespace playCS
{
    class Program
    {
        //TODO find a way to switch entry point
        static void Main2(string[] args)
        {
            Console.WriteLine("Main2!");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // ConsoleEnhance.Rainbow();
            PlayLinq.Play();
            // PlayAdvance.Play();
            // PlayAsyncAwait.Play();
            // CancelParallelLoops.CancelParallelLoops.Play();
            // PlayParallel.PlayParallel.Play();
            // PlayTaskAndParallel.Play();
            // PlayTuple.Play();
            // PlayReflection.Play();
            // PlayReflectionAdvance.Play();
            // PlayEvent.Play();
            // PlayUnicorn.Play();
            // PlayNull.Play();
        }
    }
}