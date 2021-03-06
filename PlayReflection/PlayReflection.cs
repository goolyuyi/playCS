using System;
using System.Linq;
using System.Reflection;

namespace playCS
{
    class SomeMethods
    {
        public int K { get; set; }
        public string D { get; set; }

        public override string ToString()
        {
            return $"{nameof(K)}: {K}, {nameof(D)}: {D}";
        }

        public SomeMethods()
        {
            //Self Awareness!
            var cur = MethodInfo.GetCurrentMethod();
            var t = cur.DeclaringType;
            Console.WriteLine(t.FullName + "." + cur);
        }

        public SomeMethods(int a) : this()
        {
            var cur = MethodBase.GetCurrentMethod();
            var t = cur.DeclaringType;
            Console.WriteLine(t.FullName + "." + cur);
        }

        public SomeMethods(string a) : this()
        {
            var cur = MethodBase.GetCurrentMethod();
            var t = cur.DeclaringType;
            Console.WriteLine(t.FullName + "." + cur);
        }

        public SomeMethods(float a, string b) : this()
        {
            Console.WriteLine(a + ",," + b);
            this.K = (int) a;
            this.D = b;

            var cur = MethodBase.GetCurrentMethod();
            var t = cur.DeclaringType;
            Console.WriteLine(t.FullName + "." + cur);
        }
    }

    public static class PlayReflection
    {
        public static void Play()
        {
            PlayAssembly();
            PlayType();
            PlayMethods();
            PlayMembers();
        }

        static void PlayMembers()
        {
            var t = typeof(SomeMethods);
            var ms = t.GetMembers();
            foreach (var memberInfo in ms)
            {
                Console.WriteLine(memberInfo);
            }
        }

        static void PlayType()
        {
            var t = typeof(object);
            Console.WriteLine(t);
            var ms = t.GetMethods();
            Console.WriteLine(ms);
            var m = ms[0];
        }

        static void RainbowLine(params object[] ins)
        {
            foreach (var inn in ins)
            {
                Console.WriteLine(inn.GetType());
            }
        }


        private static void PlayMethods()
        {
            var @y = new SomeMethods();
            @y = new SomeMethods(5);
            Console.WriteLine(@y);

            var sm = typeof(SomeMethods);
            Console.WriteLine(sm);

            var inputs = new object[] {MathF.E, DateTime.Now.ToString()};
            var inputsTypes = inputs.Select((i) => i.GetType()).ToArray();

            var smc = sm.GetConstructor(inputsTypes);
            Console.WriteLine(smc);
            var res = smc?.Invoke(inputs);


            Console.WriteLine(res);
            RainbowLine(1, 2, "123");
        }

        static void PlayAssembly()
        {
            var callingAssembly = Assembly.GetCallingAssembly();
            Console.WriteLine(callingAssembly.Location);
            Console.WriteLine(callingAssembly.Modules);
            var callingModules = callingAssembly.GetModules()[0];
            Console.WriteLine(callingModules.Name);
            var curts = callingModules.GetTypes();
        }
    }
}