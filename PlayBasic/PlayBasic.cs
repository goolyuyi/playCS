using System;
using System.Collections;
using System.Collections.Generic;

namespace playCS
{
    struct AStruct
    {
        public string Name;

        public AStruct(string name)
        {
            Name = name;
        }
    }

    [Flags]
    enum WeaponStyle
    {
        Knife = 1,
        Sword = 2,
        Blade = 4,
        Pistol = 8,
        Rifle = 16
    }

    

    public static class PlayBasic
    {
        static void Func(int[] a, object b)
        {
        }


        public static void Play()
        {
            
            
            var strList = new List<string> {"a", "b", "5555"};
            Console.WriteLine("{0}", string.Join(",", strList));

            var intArray = new int[] {1, 2, 3, 4, 5};
            //NOTE ^n last n (c# 8.0)
            Console.WriteLine(intArray[^1]);
            //c# 8.0
            Console.WriteLine(intArray[1..2]);

            Console.WriteLine(intArray);
            Console.WriteLine(String.Join(",", intArray));

            //using will call IDispose automatically
            using (var dog = new Dog(name: "mic", age: 13))
            {
                Console.WriteLine(dog);
            }

            var cat = new Cat(null, secretName: "jelly") {Name = "ginger", Age = 10};

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(cat.ToString());
            Console.ResetColor();

            //nullable
            int? ni = 5;
            ni = null;
            Console.WriteLine(ni ?? 0); //means: if null then 0 
            var c = 5 + ni; //null
            Console.WriteLine(c);

            //enum
            WeaponStyle s = WeaponStyle.Knife | WeaponStyle.Pistol;
            Console.WriteLine(value: $"{s}, Knife:{s.HasFlag(WeaponStyle.Knife)}");

            //convert
            //is as (type)
            //NOTE is const/null is also works
            if (strList is ICollection<string> strCol)
            {
                //NOTE 快捷语法 strCol is a ICollection<string> here
                Console.WriteLine(strCol.Count);
            }

            //init params
            Func(a: new[] {1, 2, 3, 4}, new { });
            
            dynamic d = 1;
            var testSum = d + 3;
            // Rest the mouse pointer over testSum in the following statement.
            System.Console.WriteLine(testSum);
        }
    }



    struct Cat
    {
        public string Name;
        public int Age;
        private readonly string _secretName;

        public Cat(string name, string secretName) : this()
        {
            Name = name;
            this._secretName = secretName;
        }

        public override string ToString()
        {
            return $"{{{{{Name},{Age}:{_secretName}}}}}";
        }
    }

    class Dog : IDisposable
    {
        public Dog(string name, int age)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _age = age;
        }

        public void Dispose()
        {
            Console.WriteLine("dog died.");
        }

        string _name;
        int _age;

        public override string ToString()
        {
            return $"{nameof(_name)}: {_name}, {nameof(_age)}: {_age}";
        }
    }
}