using System;

namespace playCS
{
    public class PlaySpan
    {
        public static void Play()
        {
            //stackalloc force alloc in stack
            Span<int> t = stackalloc int[50];
            
            int length = 1000;
            Span<byte> buffer = length <= 1024 ? stackalloc byte[length] : new byte[length];
        }
        
        
    }
}