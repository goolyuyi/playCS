using System;

namespace playCS
{
    //NOTE: class & anoymous class: ref type
    //struct & tuple: value type

    //NOTE: record is a immutable ref type!

    //NOTE: record will auto create
    // value-based equal method
    // override GetHashCode()
    // Copy and Clone members
    // PrintMembers and ToString() 有统一的格式(方便)
    public record Person
    {
        public string LastName { get; }
        public string FirstName { get; }

        public Person(string first, string last) => (FirstName, LastName) = (first, last);
    }

    //NOTE: inherit record is ok!
    public record Teacher : Person
    {
        public string Subject { get; }

        public Teacher(string first, string last, string sub)
            : base(first, last) => Subject = sub;
    }


    public class PlayNine
    {

        public static void Play()
        {
            //record!
            var yuyi = new Person(first:"Yi", last: "Yu");
            //you can't init assign: { LastName="aaa"} ;
            //you can't assign: p.LastName = "uy";

            var yuyi2 = new Person(first: "Yi", last: "Yu");

            Console.WriteLine(yuyi == yuyi2);
            Console.WriteLine(yuyi.Equals(yuyi2));
            Console.WriteLine(yuyi.GetHashCode());
            Console.WriteLine(yuyi2.GetHashCode());

            Console.WriteLine(yuyi.ToString());
            
        }
    }
}