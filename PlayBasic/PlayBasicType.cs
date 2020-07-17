using System;
using System.Collections.Generic;

namespace playCS
{
    public class PlayBasicType
    {
        public PlayBasicType()
        {
            var longList = new List<string> {"a", "b", "5555"};
            Console.WriteLine("{0}", string.Join(",", longList));

            var arrayInt = new int[] {1, 2, 3, 4, 5};
            Console.WriteLine(arrayInt);
            Console.WriteLine(String.Join(",", arrayInt));

            using (var dog = new Dog(name: "mic", age: 13))
            {
                Console.WriteLine(dog);
            }

            var cat = new Cat(null, secretName: "jelly") {Name = "ginger", Age = 10};


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(cat.ToString());
            Console.ResetColor();

            int? ni = 5;
            ni = null;
            Console.WriteLine(ni ?? 0);
            var c = 5 + ni;
            Console.WriteLine(c);
            
            WeaponStyle s = WeaponStyle.Knife | WeaponStyle.Pistol;
            Console.WriteLine(value: $"{s}, Knife:{s.HasFlag(WeaponStyle.Knife)}");

            var uni = new Unicorn {Name = "Jane!", Color = "red"};
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(uni[2]);
            Console.WriteLine(uni);
            Console.WriteLine(Unicorn.Big("aaaaaaa"));
            Console.ResetColor();


            var names1 = ("Peter", "Parker");
            Console.WriteLine(names1.Item1);
            var tp = names1.ToTuple();

            (string FirstName, string LastName) names2 = ("Peter", "Parker");
            Console.WriteLine(names2.FirstName);
            var names3 = (First: "Peter", Last: "Parker");
            Console.WriteLine(names3.Last);

            //deconstruct
            (string firstName, string lastName) = names3;
            var (_, last) = names3;
            Console.WriteLine($"{firstName} {lastName} {last}");

            Console.WriteLine(P((x) => x * 2)(6));
        }

        delegate int VV(int x);

        VV P(VV vvfunc)
        {
            var mm = 5;
            VV v = x => vvfunc(x) + mm;
            return v;
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

    class Bull
    {
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