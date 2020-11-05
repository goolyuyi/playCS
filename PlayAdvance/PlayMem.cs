using System;
using System.Buffers;

namespace playCS
{
    public class PlayMem
    {
        public static void Play()
        {
            //NOTE managed mem
            Span<int> span = new int[100];

            //NOTE from stack
            Span<int> span2 = stackalloc int[10];

            ReadOnlySpan<int> readOnlySpan = span;

            //NOTE To Mem
            "aaaa".AsSpan();
            "aaaa".AsMemory();

            var toMem = new Memory<int>(span.ToArray());
            //NOTE MemoryManager<T> an abstract base class that can be used to replace the implementation of Memory<T> so that Memory<T> can be backed by additional types, such as safe handles. MemoryManager<T> is intended for advanced scenarios.

            //NOTE memory exists on heaps
            //NOTE because of this, memory can be used on async and cross thread
            //NOTE use owner mode
            IMemoryOwner<int> memoryOwner = MemoryPool<int>.Shared.Rent(10);
            using (memoryOwner)
            {
                //NOTE to Span
                // memoryOwner.Memory.Span
                Console.WriteLine(memoryOwner.Memory);
            }

            // follow more rule here!
            // https://docs.microsoft.com/zh-cn/dotnet/standard/memory-and-spans/memory-t-usage-guidelines#usage-guidelines
            
            //NOTE rent from array pool
            var intArrayFromPool = ArrayPool<int>.Shared.Rent(10);
            ArrayPool<int>.Shared.Return(intArrayFromPool, false);
        }
    }
}