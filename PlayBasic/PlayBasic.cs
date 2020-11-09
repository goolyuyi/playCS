using System;
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


    //NOTE Indicates that an enumeration can be treated as a bit field
    [Flags]
    enum AEnumWeaponStyle
    {
        Knife = 1,
        Sword = 2,
        Blade = 4,
        Pistol = 8,
        Rifle = 16
    }

    public static class PlayBasic
    {
        static void AFunc(int[] a, object b)
        {
        }



        public static void Play()
        {
            //NOTE new somethings
            var strList = new List<string> {"a", "b", "5555"};
            var cat = new Cat(null, secretName: "jelly") {Name = "ginger", Age = 10};
            var intArray = new int[] {1, 2, 3, 4, 5};

            Console.WriteLine("{0}", string.Join(",", strList));

            //NOTE ^n last n (c# 8.0)
            Console.WriteLine(intArray[^1]);

            //NOTE range of array(c# 8.0)
            Console.WriteLine(intArray[1..2]);

            Console.WriteLine(intArray);
            Console.WriteLine(String.Join(",", intArray));

            //num
            var intA = 111_222; //111_222
            var intB = 0x111_222; //111 222 in hex
            var intC = 0b1101_0010_1001; //1101 0010 1001 in binary
            var longA = 111_222L;
            var longB = 111_222UL; //unsigned
            var longC = 0x1f_f1L; //hex
            var floatA = 1.23f; //float
            var doubleA = 1.23d; //double
            var decimalA = 1.23m; //decimal 128 bit

            //using will call IDispose automatically
            using (var dog = new Dog(name: "mic", age: 13))
            {
                Console.WriteLine(dog);
            }

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
            AEnumWeaponStyle s = AEnumWeaponStyle.Knife | AEnumWeaponStyle.Pistol;
            Console.WriteLine(value: $"{s}, Knife:{s.HasFlag(AEnumWeaponStyle.Knife)}");

            //convert
            //is as (type)
            //NOTE is const/null is also works
            if (strList is ICollection<string> strConverted)
            {
                //NOTE 快捷语法 strCol is a ICollection<string> here
                Console.WriteLine(strConverted.Count);
            }

            //init params
            AFunc(a: new[] {1, 2, 3, 4}, new { });

            dynamic d = 1;
            var testSum = d + 3;
            Console.WriteLine(testSum);

            d = "string";
            Console.WriteLine(d);

            var W = AEnumWeaponStyle.Knife;
            //NOTE new style of switch, looks prettier
            var WStr = W switch
            {
                AEnumWeaponStyle.Knife => "Tulong",
                AEnumWeaponStyle.Sword => "Yaki",
                _ => "Weapon"
            };

            var NN = -4;
            var res = NN switch
            {
                _ when NN > 5 => "Big",
                _ when NN < 0 => "Small",
                _ => "Ok"
            };

            var NC = (1, 2);
            var res2 = NC switch
            {
                var (x, y) when x + y > 5 => "Big",
                var (x, y) when x + y < 0 => "Small",
                _ => "Ok"
            };

            //NOTE exception filter
            try
            {
                throw new ArgumentOutOfRangeException("test", "err");
            }
            catch (ArgumentOutOfRangeException e) when (e.ParamName == "test")
            {
                Console.WriteLine(e);
            }
        }
    }


    struct Cat
    {
        public string Name;
        public int Age;

        //readonly is not static nor const
        //readonly meant once the var has been written , it can not be write again
        private readonly string _secretName;

        public Cat(string name, string secretName) : this()
        {
            Name = name;
            _secretName = secretName;
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