using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PPP
{
    public class PPP
    {
        public class A
        {
        }

        class B
        {
        }
    }

    class QQQ
    {
    }
}

namespace playCS
{
    class AClassToBeReflected
    {
        public long ALong { get; set; }
        public long BLong;
        private long CLong;


        public AClassToBeReflected(int a)
        {
            BLong = a;
        }

        public double Calc()
        {
            return Math.Sqrt(BLong);
        }
    }


    public static class PlayReflectionAdvance
    {
        static void GFunc<T>(T input)
        {
            var type = typeof(T);
            Console.WriteLine(type);
            Console.WriteLine(input);
        }

        delegate void GDelegate<T>(T input);


        static void PlayReflection()
        {
            var type = typeof(AClassToBeReflected);
        }

        static void GetAllTypes()
        {
            var asm = Assembly.GetEntryAssembly();
            var m = asm.GetModules();
            var ts = m[0].GetTypes();
            foreach (var type in ts) Console.WriteLine(type);
        }

        static void Generic()
        {
            GFunc(56);
            GDelegate<float> gDelegate = GFunc;

            //NOTE this is a delegate type
            var tg = gDelegate.GetType();

            var closeFunc = gDelegate.Method;
            var openFunc = gDelegate.Method.GetGenericMethodDefinition();

            Console.WriteLine(closeFunc.IsGenericMethod);
            Console.WriteLine(closeFunc.IsGenericMethodDefinition);

            var openList = typeof(List<>);
            Console.WriteLine(openList.IsGenericType); //NOTE only here can use `<>`
            Console.WriteLine(openList.IsGenericTypeDefinition); //NOTE true here

            var closeList = typeof(List<long>);
            Console.WriteLine(closeList.IsGenericTypeDefinition); //NOTE false here

            //open - 还没完全实化
            //close - 所有形参都实化了
            Console.WriteLine(openList.ContainsGenericParameters); //true
            Console.WriteLine(closeList.ContainsGenericParameters); //false
            Console.WriteLine(gDelegate.Method.ContainsGenericParameters); //false

            //用 MakeGeneric...实化
            //取得泛化版本 typeOfList.GetGenericTypeDefinition()

            //取得实化泛型的那些 types
            var t = closeList.GetGenericArguments(); //NOTE type long here

            Console.WriteLine(openFunc.GetGenericArguments()[0].IsGenericParameter); //NOTE True
        }


        static void NamespaceReflection()
        {
            var asm = MethodBase.GetCurrentMethod().DeclaringType?.Assembly;
            var pppNs = asm.GetModules()[0].GetTypes().Where((i) => !string.Equals(i.Namespace, null,
                                                                        StringComparison.Ordinal) &&
                                                                    i.Namespace == "PPP").ToArray();
            
            foreach (var pppN in pppNs)
            {
                Console.WriteLine(pppN);
            }
        }

        public static void Play()
        {
            GetAllTypes();
            // Generic();
            NamespaceReflection();
        }
    }
}