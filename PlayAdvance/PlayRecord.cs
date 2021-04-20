using System;

namespace playCS
{
    public class PlayRecord
    {
        #region Record

        //a record def
        record ARecord(long id, string name, string type);

        //a record def 
        public record Person
        {
            public string LastName;
            public string FirstName;

            public Person(string first, string last) => (FirstName, LastName) = (first, last);
        }

        //record will auto create:
        // * value-based equal method
        // * override GetHashCode()
        // * Copy and Clone members
        // * PrintMembers and ToString() 有统一的格式(方便)


        //NOTE: class & anoymous class: ref type
        //struct & tuple: value type
        //record is a immutable ref type!
        public static void Play()
        {
            var yuyi = new Person(first: "Yi", last: "Yu");

            //you can't init assign: { LastName="aaa"} ;
            //you can't assign: p.LastName = "uy";

            var yuyi2 = new Person(first: "Yi", last: "Yu");

            //NOTE: Equality is value-based
            Console.WriteLine(yuyi == yuyi2);
            Console.WriteLine(yuyi.Equals(yuyi2));

            //NOTE: record auto gen hash code
            Console.WriteLine(yuyi.GetHashCode());
            Console.WriteLine(yuyi2.GetHashCode());

            Console.WriteLine(yuyi.ToString());

            //NOTE clone and change
            var yuyi3 = yuyi2 with {FirstName = "guai"};
            Console.WriteLine(yuyi3);
        }
        
        //inherit record is ok!
        public record Teacher : Person
        {
            public string Subject { get; }

            public Teacher(string first, string last, string sub)
                : base(first, last) => Subject = sub;
        }

        public record PersonRec(string FirstName, string LastName);
        public record TeacherRec(string FirstName, string LastName,
                string Subject)
            : PersonRec(FirstName, LastName);
        public sealed record StudentRec(string FirstName,
                string LastName, int Level)
            : PersonRec(FirstName, LastName);

        #endregion
    }
}