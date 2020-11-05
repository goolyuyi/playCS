using System;
using playCS.PlayIO;
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

            
            // PlayUnicorn.Play();
            // PlaySpan.Play();
            //PlayNullable.Play();
            // PlayBasic.Play();
            // PlayLinq.Play();
            // PlayLazy.Play();
            // PlayConvert.PlayConvert.Play();
            //PlayIO.PlayIO.Play();
            // PlayNine.Play();
            // PlayUnsafe.Play();
            
            PlayPipeline.Play();
        }
    }
}