using System;
using playCS.PlayIO;

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
            
            // PlayBasic.Play();
            // PlayUnicorn.Play();
            // PlaySpan.Play();
            // PlayNullable.Play();
            // PlayStringFormatter.Play();
            // PlayReflection.Play();
            // PlayLinq.Play();
            // PlayLazy.Play();
            // PlayConvert.PlayConvert.Play();
            // PlayIO.PlayIO.Play();
            PlayPipeline.Play();
            // PlayNine.Play();
            // PlayUnsafe.Play();
            // PlayPipeline.Play();
            // PlayRegex.PlayRegex.Play();
        }
    }
}