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

            PlayBasic.Play();
            // PlayLinq.Play();
        }
    }
}