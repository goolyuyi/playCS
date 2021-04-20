using System;

namespace playCS
{
    //NOTE must manually allow unsafe code via proj config
    unsafe struct UnsafeName
    {
        public fixed char name[30];
    }

    public class PlayUnsafe
    {
        public static unsafe void Play()
        {
            UnsafeName a;
            a.name[1] = 'a';

            //use c like pointer here
            char* A;
            A = a.name;
            *(A + 3) = 'b';

            //alloc in stack
            Span<int> B = stackalloc int[10];
            var C = stackalloc int[10];
            ReadOnlySpan<int> D = stackalloc int[10];

            //NOTE discard & release all stackalloc after method done
        }
    }
}