using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text;

namespace playCS
{
    public class PlayLinq
    {
        #region #DataStructs

        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;
            public int Year;

            public override string ToString()
            {


                return
                    $"{nameof(Scores)}: {Scores}, {nameof(First)}: {First}, {nameof(Last)}: {Last}, {nameof(ID)}: {ID} {nameof(Year)}:{Year}";
            }
        }

        static List<Student> students = new List<Student>
        {
            new Student
            {
                Year = 2019, First = "Svetlana", Last = "Omelchenko", ID = 111, Scores = new List<int> {97, 92, 81, 60}
            },
            new Student
            {
                Year = 2019, First = "Claire", Last = "O'Donnell", ID = 112, Scores = new List<int> {75, 84, 91, 39}
            },
            new Student
            {
                Year = 2019, First = "Sven", Last = "Mortensen", ID = 113, Scores = new List<int> {88, 94, 65, 91}
            },
            new Student
            {
                Year = 2018, First = "Cesar", Last = "Garcia", ID = 114, Scores = new List<int> {97, 89, 85, 82}
            },
            new Student
            {
                Year = 2018, First = "Debra", Last = "Garcia", ID = 115, Scores = new List<int> {35, 72, 91, 70}
            },
            new Student
            {
                Year = 2018, First = "Fadi", Last = "Fakhouri", ID = 116, Scores = new List<int> {99, 86, 90, 94}
            },
            new Student
            {
                Year = 2018, First = "Hanying", Last = "Feng", ID = 117, Scores = new List<int> {93, 92, 80, 87}
            },
            new Student
            {
                Year = 2017, First = "Hugo", Last = "Garcia", ID = 118, Scores = new List<int> {92, 90, 83, 78}
            },
            new Student
            {
                Year = 2017, First = "Lance", Last = "Tucker", ID = 119, Scores = new List<int> {68, 79, 88, 92}
            },
            new Student
            {
                Year = 2016, First = "Terry", Last = "Adams", ID = 120, Scores = new List<int> {99, 82, 81, 79}
            },
            new Student
            {
                Year = 2015, First = "Eugene", Last = "Zabokritski", ID = 121, Scores = new List<int> {96, 85, 91, 60}
            },
            new Student
            {
                Year = 2016, First = "Michael", Last = "Tucker", ID = 122, Scores = new List<int> {94, 92, 91, 91}
            }
        };

        #endregion

        #region DataStructs2

        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public override string ToString()
            {
                return $"{nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}";
            }
        }

        class Pet
        {
            public string Name { get; set; }
            public Person Owner { get; set; }

            public override string ToString()
            {
                return $"{nameof(Name)}: {Name}, {nameof(Owner)}: {Owner}";
            }
        }

        class Cat : Pet
        {
        }

        class Dog : Pet
        {
        }

        static Person magnus = new Person {FirstName = "Magnus", LastName = "Hedlund"};
        static Person terry = new Person {FirstName = "Terry", LastName = "Adams"};
        static Person charlotte = new Person {FirstName = "Charlotte", LastName = "Weiss"};
        static Person arlene = new Person {FirstName = "Arlene", LastName = "Huff"};
        static Person rui = new Person {FirstName = "Rui", LastName = "Raposo"};
        static Person phyllis = new Person {FirstName = "Phyllis", LastName = "Harris"};

        static Cat barley = new Cat {Name = "Barley", Owner = terry};
        static Cat boots = new Cat {Name = "Boots", Owner = terry};
        static Cat whiskers = new Cat {Name = "Whiskers", Owner = charlotte};
        static Cat bluemoon = new Cat {Name = "Blue Moon", Owner = rui};
        static Cat daisy = new Cat {Name = "Daisy", Owner = magnus};


        static Dog fourwheeldrive = new Dog {Name = "Four Wheel Drive", Owner = phyllis};
        static Dog duke = new Dog {Name = "Duke", Owner = magnus};
        static Dog denim = new Dog {Name = "Denim", Owner = terry};
        static Dog wiley = new Dog {Name = "Wiley", Owner = charlotte};
        static Dog snoopy = new Dog {Name = "Snoopy", Owner = rui};
        static Dog snickers = new Dog {Name = "Snickers", Owner = arlene};

        static List<Person> people =
            new List<Person> {magnus, terry, charlotte, arlene, rui, phyllis};

        static List<Cat> cats =
            new List<Cat> {barley, boots, whiskers, bluemoon, daisy};

        static List<Dog> dogs =
            new List<Dog> {fourwheeldrive, duke, denim, wiley, snoopy, snickers};

        #endregion

        public static void PlayJoin()
        {
            PlayJoinBasic();
            PlayJoinGroup();
            PlayJoinCross();
        }

        public static void PlayJoinCross()
        {
            var query = from d in dogs
                from c in cats
                select new {d, c};

            foreach (var x1 in query)
            {
                Console.WriteLine(x1.d);
                Console.WriteLine(x1.c);
            }

            Console.WriteLine(query.Count());
        }

        static void PlayJoinGroup()
        {
            var query = from person in people
                join pet in cats on person equals pet.Owner into gj
                select new {OwnerName = person.FirstName, Pets = from g in gj select g.Name};

            foreach (var x1 in query)
            {
                Console.WriteLine($"{x1.OwnerName}+++{string.Join(',', x1.Pets)}");
            }

            //TODO
            //REVIEW think about this!
            var query4 = from d in students
                group d by d.Year
                into gyear
                from ng in (from gy in gyear
                    group gy by gy.Last)
                group ng by gyear.Key;

            foreach (var grouping in query4)
            {
                Console.WriteLine(grouping.Key);
            }
        }

        private static void PlayJoinBasic()
        {
            var query = from p in people
                join pet in dogs on p equals pet.Owner
                select new {p, pet};

            foreach (var x1 in query)
            {
                Console.WriteLine($"person: {x1.p}, pet:{x1.pet}");
            }

            //multi join
            var query2 = from p in people
                join dog in dogs on p equals dog.Owner
                join cat in cats on
                    new {Owner = p, Letter = dog.Name.Substring(0, 1)}
                    equals new {cat.Owner, Letter = cat.Name.Substring(0, 1)}
                select new {CatName = cat.Name, DogName = dog.Name};

            foreach (var x1 in query2)
            {
                Console.WriteLine($"cat:{x1.CatName} dog:{x1.DogName}");
            }
        }


        private static void StudentQueryBasic()
        {
            //NOTE linq must start with `from ... in ...`
            var query = from student in students
                where student.Last.StartsWith("F") && student.Scores.Any((i) => i > 90)
                select new
                {
                    last = student.Last, first = student.First, score = string.Join(',', student.Scores)
                };

            foreach (var i in query) Console.WriteLine(i);
        }

        private static void StudentQuerySelectMany()
        {
            //project + flatten
            //NOTE flatten effect
            var query = students.SelectMany(student => { return student.Scores; });


            Console.WriteLine(query.Average());
            StringBuilder sb = new StringBuilder();
            foreach (var i in query) sb.Append($"{i},");
            Console.WriteLine(sb);
        }

        private static void StudentQueryGroup()
        {
            var query = from s in students
                //group {projection} by {group key}
                group new {Name = s.First + s.Last} by s.Scores.Average() > 90
                into gp
                from g in gp
                select new {g.Name, gp.Key};
            foreach (var i in query) Console.WriteLine(i);
        }

        private static void StudentQueryMethodInput()
        {
            Object QMethod(Student i)
            {
                var n = DateTime.Now;
                return new {now = n, i.Year, i.Last};
            }

            var a = new Func<Student, bool>((Student s) => s.Year >= 2019);

            //NOTE query only able to use local method or lambda
            //NOTE query can't use inline lambda
            var query = from s in students
                where a(s)
                select QMethod(s);
            foreach (var b in query)
            {
                Console.WriteLine(b);
            }
        }

        private static void PlayStudentData()
        {
            StudentQueryBasic();
            StudentQuerySelectMany();
            StudentQueryMethodInput();
            StudentQueryGroup();
            StudentQueryNestGroup();
            StudentQuerySub();
        }

        private static void StudentQuerySub()
        {
            var query = from s in students
                group s by s.Year
                into yearGroup
                select new
                {
                    yearGroup.Key,
                    Best = (from s in yearGroup select s.Scores.Average()).Max()
                };

            foreach (var x1 in query)
            {
                Console.WriteLine($"Year:{x1.Key} Best:{x1.Best}");
            }
        }

        private static void StudentQueryNestGroup()
        {
            var query = from s in students
                group s by s.Last[0]
                into gp1
                from sx in (from ss in gp1
                    group ss by ss.Year)
                group sx by gp1.Key;

            var queryMethodVersion = students.GroupBy(s => s.Last[0])
                .SelectMany(
                    gp1 => (gp1.GroupBy(ss => ss.Year)),
                    (gp1, sx) => new {gp1, sx}
                )
                .GroupBy(@t => @t.gp1.Key, @t => @t.sx);

            // char group
            foreach (var i in query)
            {
                Console.WriteLine(i.Key);
                //year group
                foreach (var j in i)
                {
                    Console.WriteLine(j.Key);
                    foreach (var k in j)
                    {
                        Console.WriteLine(k);
                    }
                }
            }
        }

        class Package
        {
            public string Company;
            public double Weight;
            public long TrackingNumber;
        }

        static void LookupPlay()
        {
            //NOTE
            //Lookup<string,int> == Dictionary<string,IEnumerable<int>>
            //Lookup is immutable
            //Lookup DO NOT have constructor

            //NOTE always use GroupBy instead of Lookup for large query
            //https://stackoverflow.com/questions/10215428/why-are-tolookup-and-groupby-different

            List<Package> packages = new List<Package>
            {
                new Package {Company = "Coho Vineyard", Weight = 25.2, TrackingNumber = 89453312L},
                new Package {Company = "Lucerne Publishing", Weight = 18.7, TrackingNumber = 89112755L},
                new Package {Company = "Wingtip Toys", Weight = 6.0, TrackingNumber = 299456122L},
                new Package {Company = "Contoso Pharmaceuticals", Weight = 9.3, TrackingNumber = 670053128L},
                new Package {Company = "Wide World Importers", Weight = 33.8, TrackingNumber = 4665518773L}
            };

            Lookup<char, string> lookup = (Lookup<char, string>) packages.ToLookup(
                p => Convert.ToChar(p.Company[0]),
                p => p.Company + " " + p.TrackingNumber);

            foreach (IGrouping<char, string> packageGroup in lookup)
            {
                Console.WriteLine(packageGroup.Key);
                foreach (string str in packageGroup)
                    Console.WriteLine("\t\t{0}", str);
            }
        }


        public static void Play()
        {
            PlayStudentData();
            LookupPlay();
            PlayJoin();
        }
    }
}