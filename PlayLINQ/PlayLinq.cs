using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace playCS
{
    public class PlayLinq
    {
        #region DATA STRUCTS

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
        
        private static void Basic()
        {
            var query = from student in students
                where student.Last.StartsWith("G")
                select student
                into student
                from score in student.Scores
                where score < 60
                select new
                {
                    score, last = student.Last
                };

            foreach (var i in query) Console.WriteLine(i);

            //SelectMany means flat it!
            var query2 = students.SelectMany(student => { return student.Scores; });
            Console.WriteLine(query2.Average());
            StringBuilder sb = new StringBuilder();

            foreach (var i in query2) sb.Append($"{i},");
            Console.WriteLine(sb);

            //JUST CAN'T USE STATEMENTS IN QUERY!
            // var query3 = from s in students select 
            // {
            //     var n = DateTime.Now;
            //     return s;
            //
            // }

            //DO THIS!
            Func<Student, String> xxx = (s) => { return $"{DateTime.Now}:{s.First} {s.Last}"; };
            var query3 = from s in students
                select xxx(s);
            foreach (var i in query3)
                Console.WriteLine(i);


            var query4 = from s in students
                group new {Name = s.First + s.Last} by s.Scores.Average() > 90
                into gp
                from g in gp
                select new {g.Name, gp.Key};
            foreach (var i in query4) Console.WriteLine(i);

            var query5 = from s in students
                group s by s.Last[0]
                into gp1
                from sx in (from ss in gp1
                    group ss by ss.Year)
                group sx by gp1.Key;
            foreach (var i in query5)
            {
                Console.WriteLine(i.Key);
                foreach (var j in i)
                {
                    Console.WriteLine(j.Key);
                    foreach (var k in j)
                    {
                        Console.WriteLine(k);
                    }
                }
            }

            var query6 = students.Select(s => { return DateTime.Now; });
            var query7 = students.GroupBy(s => s.Last[0], s => s.First);
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
            //* Lookup<string,int> == Dictionary<string,IEnumerable<string>>
            //* Lookup is immutable
            //* Lookup do not have constructor

            // Create a list of Packages to put into a Lookup data structure.
            List<Package> packages = new List<Package>
            {
                new Package {Company = "Coho Vineyard", Weight = 25.2, TrackingNumber = 89453312L},
                new Package {Company = "Lucerne Publishing", Weight = 18.7, TrackingNumber = 89112755L},
                new Package {Company = "Wingtip Toys", Weight = 6.0, TrackingNumber = 299456122L},
                new Package {Company = "Contoso Pharmaceuticals", Weight = 9.3, TrackingNumber = 670053128L},
                new Package {Company = "Wide World Importers", Weight = 33.8, TrackingNumber = 4665518773L}
            };

            // Create a Lookup to organize the packages. Use the first character of Company as the key value.
            // Select Company appended to TrackingNumber for each element value in the Lookup.
            Lookup<char, string> lookup = (Lookup<char, string>) packages.ToLookup(
                p => Convert.ToChar(p.Company[0]),
                p => p.Company + " " + p.TrackingNumber);

            // Iterate through each IGrouping in the Lookup and output the contents.
            foreach (IGrouping<char, string> packageGroup in lookup)
            {
                // Print the key value of the IGrouping.
                Console.WriteLine(packageGroup.Key);
                // Iterate through each value in the IGrouping and print its value.
                foreach (string str in packageGroup)
                    Console.WriteLine("    {0}", str);
            }
        }
        
        
        
        
        public static void Play()
        {
            Basic();
            LookupPlay();
        }
    }
}