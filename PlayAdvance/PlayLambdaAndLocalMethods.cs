using System;

namespace playCS
{
    public class PlayLambdaAndLocalMethods
    {
        public static void Play()
        {
            PlayLocalMethod();
            PlayLambda();
        }
        
        static void PlayLocalMethod()
        {
            //DO THIS
            int count = 0;

            string LocalFunc(string s)
            {
                count++;
                return $"{s}::{s.Length}";
            }

            Console.WriteLine(LocalFunc("aaaaaa"));

            //NOT THIS
            Func<string, string> LocalLamda = (string s) =>
            {
                count++;
                return $"{s}::{s.Length}";
            };
            Console.WriteLine(LocalLamda("aaaaa"));
        }

        delegate int DeleFunc(int x);

        static void PlayLambda()
        {
            DeleFunc deleFuncNLambda = (int x) =>
            {
                for (var i = 0; i < 10; i++, x += i) ;
                return x + 1;
            };

            Console.WriteLine("{0},{1:N}", deleFuncNLambda, deleFuncNLambda(5));
        }
    }
}