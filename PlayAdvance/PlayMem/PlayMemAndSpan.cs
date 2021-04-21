using System;
using System.Buffers;

namespace playCS
{
    public class PlayMemAndSpan
    {
        public static void Play()
        {
            // follow more rule here!
            // https://docs.microsoft.com/zh-cn/dotnet/standard/memory-and-spans/memory-t-usage-guidelines#usage-guidelines

            //span in stack vs memory in stack and heap 
            //so span doesn't support heap feature, like class field 
            Span<int> span = new int[100];

            ReadOnlySpan<int> readOnlySpan = span;

            "aaaa".AsSpan();
            "aaaa".AsMemory();

            var toMem = new Memory<int>(span.ToArray());

            IMemoryOwner<int> memoryOwner = MemoryPool<int>.Shared.Rent(10);
            using (memoryOwner)
            {
                Console.WriteLine(memoryOwner.Memory);
            }

            //rent from array pool
            var intArrayFromPool = ArrayPool<int>.Shared.Rent(10);
            ArrayPool<int>.Shared.Return(intArrayFromPool, false);
        }
    }
}