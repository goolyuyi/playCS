using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace playCS
{
    public interface Runable
    {
        void Run(int times)
        {
            foreach (var _ in Enumerable.Range(0, times))
            {
                Console.WriteLine("Run");
            }
        }
        void Stop();
    }

    public static class PlayUnicorn
    {
        public static void Play()
        {
            var unicorn = new Unicorn() {Name = "Pony", Color = "Blue"};

            //Deconstruct Unicorn
            //NOTE _ means discard
            var (n, c1, _) = unicorn;
            Console.WriteLine($"{n},{c1}");

            //Enum Unicorn
            foreach (var s in unicorn)
            {
                Console.WriteLine(s);
            }

            //Equal Unicorn
            Console.WriteLine(unicorn == null);

            //Clone Unicorn
            var c = new Unicorn(unicorn);

            //Compare Unicorn
            c.Name = "YiJiang";
            Console.WriteLine(c.CompareTo(unicorn) > 0 ? "bigger" : "smaller");

            //Parcial Unicorn
            unicorn.Da();

            //Mixin Unicorn (c# 8.0)
            if (unicorn is Runable runable)
            {
                runable.Run(5);
            }

            unicorn.Stop();

            //Indexer Unicorn
            Console.WriteLine(unicorn[5]);

            //Any Param Unicorn
            unicorn.AnyParams(1, 2, 3, "aaa", "bbb");
            //Convert Unicorn
            //NOTE Very Ambiguity,DONT USE OFTEN! Only use it on mathematically purpose
            byte[] b = unicorn;
            Unicorn bb = (Unicorn) b;

            //Operator Unicorn
            Console.WriteLine(unicorn + c);

            //异常筛选
        }
    }


    public partial class Unicorn
    {
        public void Da()
        {
            Console.WriteLine("Da");
        }

        public void Stop()
        {
            Console.WriteLine("Stop");
        }
    }


    //NOTE unicorn是超级 class,实现了 c#一切功能!
    public partial class Unicorn : IDisposable, IEnumerable<string>, IEquatable<Unicorn>, ICloneable,
        IComparable<Unicorn>
    {
        public string Name;
        public string Color { set; get; }

        private readonly Random _random = new Random();

        public Unicorn()
        {
        }


        public void AnyParams(params object[] inn)
        {
            foreach (var @ins in inn)
            {
                Console.WriteLine(@ins);
            }
        }

        #region #Equality

        //NOTE 至少要实现以下3个方法
        // https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type
        //rider 自动生成

        //IEquatable
        public bool Equals(Unicorn other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && Equals(_random, other._random) && Color == other.Color;
        }

        //Override Object Class
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Unicorn) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, _random, Color);
        }

        #endregion

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Color)}: {Color}";
        }

        #region #Cloneable

        public object Clone()
        {
            return new Unicorn(this);
        }

        public Unicorn(Unicorn src)
        {
            Name = src.Name;
            Color = src.Color;
        }

        #endregion

        //indexer
        public int this[int i]
        {
            get { return i * 2; }
        }

        //lambda express
        public static bool Big(object x) => x?.ToString().Length > 5;


        #region #Enumerable

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //NOTE IEnumerable和 IEnumerator 都可以用 yield return/break
        //NOTE yield return syntax 语法简写
        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < 5; i++)
            {
                yield return "Unicorn walking:" + i;
            }
        }

        #endregion

        #region #特殊函数

        //NOTE 这里释放资源
        //NOTE 可 Async: IAsyncDisposable
        //NOTE using {} syntax
        public void Dispose()
        {
            Console.WriteLine("Dispose here");
        }

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

        #region #Comparable

        public int CompareTo(Unicorn other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);
            if (nameComparison != 0) return nameComparison;
            return string.Compare(Color, other.Color, StringComparison.Ordinal);
        }

        #endregion


        #region #Type Convert

        public static implicit operator byte[](Unicorn u) => Encoding.UTF8.GetBytes(u.Name);

        public static explicit operator Unicorn(byte[] b)
        {
            var res = new Unicorn();
            res.Name = Encoding.UTF8.GetString(b);
            return res;
        }

        #endregion

        #region #Operators

        public static Unicorn operator +(Unicorn a, Unicorn b)
        {
            var res = new Unicorn();
            res.Name = a.Name + b.Name;
            res.Color = a.Color + b.Color;
            return res;
        }

        #endregion
    }
}