using System;
using System.Collections.Generic;

namespace playCS
{
    public static class PlayAdvance
    {
        public static void Play()
        {
            Methods.PlayLocalMethod();
            AtSymbolAndparamsKeyWord(1, 2, 3);
        }

        static void AtSymbolAndparamsKeyWord(params int[] inn)
        {
            foreach (var @ins in inn)
            {
                Console.WriteLine(@ins);
            }
        }
    }

    public static class ExtClass
    {
        public static int Len2(this String i)
        {
            return i.Length + 2;
        }


        public static void ExtMethod()
        {
        }
    }

    class Methods
    {
        private static string ss;

        static ref string StrMake()
        {
            return ref ss;
        }

        //ref must init outside
        //but
        //out must init/create inside!
        static void OutMake(out List<string> s)
        {
            s = new List<string>();
            s.Add("aaaa");
        }

        public static void PlayRefReturn()
        {
            List<string> s = new List<string>();
            OutMake(out s);
        }


        public static void PlayLocalMethod()
        {
            //why?
            //清晰
            //可递归
            //避免堆内存分配,内存更少
            //静态分析

            //DO THIS
            int count = 0;

            string LocalFunc(string s)
            {
                count++;
                return $"{s}::{s.Length}";
            }

            // Console.WriteLine(LocalFunc("aaaaaa"));

            //NOT THIS
            Func<string, string> LocalLamda = (string s) =>
            {
                count++;
                return $"{s}::{s.Length}";
            };
            Console.WriteLine(LocalLamda("aaaaa"));
        }
    }
}