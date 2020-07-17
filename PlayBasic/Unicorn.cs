using System;

namespace playCS
{
    internal struct Unicorn
    {
        public string Name;
        public string Color { set; get; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Color)}: {Color}";
        }

        public int this[int i]
        {
            get { return i * 2; }
        }

        public static bool Big(object x) => x?.ToString().Length > 5;
    }
}