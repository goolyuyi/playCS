using System;

namespace playCS
{
    public static class PlayTuple
    {
        public static void Play()
        {
            var t = (50, 50);
            Console.WriteLine(t);

            //deconstruct
            (string FirstName, string LastName) names2 = ("Peter", "Parker");
            Console.WriteLine(names2.FirstName);

            //dot
            var names3 = (First: "Peter", Last: "Parker");
            Console.WriteLine(names3.Last);

            //deconstruct
            (string firstName, string lastName) = names3;
            
            // _ means discard
            var (_, last) = names3;
            Console.WriteLine($"{firstName} {lastName} {last}");
        }
    }
}