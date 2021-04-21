using System;

namespace playCS.PlayGeneric
{
    class Generic<T> where T : new()
    {
        //NOTE able to call new T() here
    }

    class Generic2<T> where T : class, IComparable<T>
    {
        public static bool Bigger( T a1, T a2)
        {
            return a1.CompareTo(a2) > 0;
        }
    }

    class Variant
    {
        static void Play()
        {
            //1.继承关系:Life < Animal < Cat < Ginger
            //in - 协变 
            //out - 逆变

            var life = new Life();
            var animal = new Animal();
            var cat = new Cat();
            var ginger = new Ginger();

            //NOTE only works with in/out key word by Func definition
            // public delegate TResult Func<in T, out TResult>(T arg);
            Func<Cat, Animal> f = (input) => { return input; };

            f(cat);
            f(ginger);
            //BAD!
            //f(animal);

            Life resLife = f(cat);
            Animal resAnimal = f(cat);
            //BAD!
            //Cat resCat = f(cat);
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