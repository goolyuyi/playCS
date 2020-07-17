using System;

namespace playCS.PlayGeneric
{
    //约束器
    //https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters//where T: struct
    //使用约束器则可调用 T 的方法
    class Gentle<T> where T : new()
    {
    }

    class Gentle2<T> where T : class, IComparable<T>
    {
        public static bool Bigger(T a1, T a2)
        {
            return a1.CompareTo(a2) > 0;
        }
    }

    //Stack<Order> orders = new Stack<Order>();
    //customers = new Stack<Customer>();
    //Stack<Order> orders = new Stack<Order>();
    //这里(对于一切的引用类型)只会创建一个专版的 Stack(不是对于 Order 和 Customer 都创建),减少代码量

    //泛型不用 boxing 和 unboxing
    //所以更快
    //List<int> just ref a int value even if it's a value type

    //预先定义好的泛型工具:
    //Predicate<T> 断言 delegate
    //Converter<TInput,TOutput> 转化 delegate
    //Comparison<T> 比较delegate
    //Action<T> void 方法的delegate


    class Variant
    {
        static void Play()
        {
            //先来了解一下协变逆变
            Animal b = new Animal();
            Life l = new Life();
            Cat d = new Cat();
            Ginger g = new Ginger();

            //ok!
            Cat dr = AnimalToCat(b);
            //ok!
            Animal br = AnimalToCat(b);
            //ok!
            Cat dr2 = AnimalToCat(d);
            //ok!
            Animal br2 = AnimalToCat(d);
            //以上4种都是合理的
            //也仅限于这4种

            //返回值只能抗变
            // Ginger gr = cov(b);

            //参数只能协变
            //Cat dr3 = cov(l);


            //那么对于接口也是
            IFace<Animal> baseObj = new FaceImpl<Animal>();
            IFace<Cat> derivedObj = new FaceImpl<Cat>();

            //逆变
            IFace<Animal> v = derivedObj;

            //协变
            // A<Derived> vv = baseObj;
        }

        interface IFace<out T>
        {
        }

        static Cat AnimalToCat(Animal input)
        {
            return new Cat();
        }

        class FaceImpl<T> : IFace<T>
        {
        }

        class Life
        {
        }

        class Animal : Life
        {
        }

        class Cat : Animal
        {
        }

        class Ginger : Cat
        {
        }
    }
}