using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace playCS
{
    public static class PlayUnicorn
    {
        static IEnumerable<string> IterUnicorn(int length)
        {
            for (int i = 0; i < length; i++)
            {
                yield return "Unicorn" + i;
            }
        }


        public static void Play()
        {
            var unicorn = new Unicorn() {Name = "Pony", Color = "Blue"};

            //Deconstruct
            //NOTE _ means discard
            var (n, c, _) = unicorn;
            Console.WriteLine($"{n},{c}");

            //NOTE 编译期自动生成 IEnumberable<string>的 class(包含Current,MoveNext等)
            foreach (var s in IterUnicorn(5))
            {
            }
        }
    }

    public class Unicorn : IDisposable, IEnumerable<string>
    {
        public string Name;
        public string Color { set; get; }

        private readonly Random _random = new Random();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Color)}: {Color}";
        }


        //indexer
        public int this[int i]
        {
            get { return i * 2; }
        }

        //lambda express
        public static bool Big(object x) => x?.ToString().Length > 5;

        //NOTE 这里释放资源
        //NOTE 可 Async: IAsyncDisposable
        //NOTE using {} syntax
        public void Dispose()
        {
            Console.WriteLine("Dispose here");
        }

        #region #Enumerable

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //NOTE IEnumerable和 IEnumerator 都可以用 yield return/break
        //NOTE yield return syntax 语法简写
        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < 100; i++)
            {
                yield return "Unicorn walking:" + i;
            }
        }

        #endregion

        #region #特殊函数

        //Finalize
        //NOTE no exception throw
        //NOTE safe guard 一定会被调用!
        //NOTE not useful, only for gc!
        ~Unicorn()
        {
            Console.WriteLine("Finalized here");
        }

        //NOTE Custom deconstruct for tuple
        //https://docs.microsoft.com/zh-cn/dotnet/csharp/deconstruct
        public void Deconstruct(out string name, out string color, out int random)
        {
            name = "Des:" + Name;
            color = "Des:" + Color;
            random = _random.Next();
        }

        #endregion

        #region #Comparer

        private sealed class NameColorEqualityComparer : IEqualityComparer<Unicorn>
        {
            public bool Equals(Unicorn x, Unicorn y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Name == y.Name && x.Color == y.Color;
            }

            public int GetHashCode(Unicorn obj)
            {
                return HashCode.Combine(obj.Name, obj.Color);
            }
        }

        public static IEqualityComparer<Unicorn> NameColorComparer { get; } = new NameColorEqualityComparer();

        #endregion


        //TODO
        //op override
        //convert method

        //equality
        //...
    }
}