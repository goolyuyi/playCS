using System;
using System.Data;

namespace playCS
{
    public class PlayException
    {
        public static void Throw()
        {
            throw new EvaluateException("401");
        }

        public static void Play()
        {
            ConditionalCatch();
        }

        private static void ConditionalCatch()
        {
            try
            {
                Throw();
            }
            //exception filer 
            catch (EvaluateException e) when (e.Message == "401")
            {
                Console.WriteLine(e);
            }
        }
    }
}