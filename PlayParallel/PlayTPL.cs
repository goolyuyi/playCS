using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace playCS.playThreadsWorld
{
    public static class PlayTPL
    {
        public static void Play()
        {
            Sum();
            LocalParallel();
        }

        static void LocalParallel()
        {
            int[] nums = Enumerable.Range(0, 1000000).ToArray();
            var cts = new CancellationTokenSource();

            double total = 0;
            object totalLock = new object();
            ParallelOptions po = new ParallelOptions();
            po.CancellationToken = cts.Token;
            
            Task.Factory.StartNew(async () =>
            {
                Console.WriteLine("500ms!");
                cts.Cancel();
                // await Task.Delay(500);
            }, cts.Token);
            try
            {
                //进一步加速:
                //初始化线程内部状态=>线程执行=>汇总
                Parallel.For<double>(0, nums.Length,
                    po, () => 0.0,
                    //线程动作
                    (j, loop, subtotal) =>
                    {
                        //同线程内不用锁
                        subtotal = Math.Sqrt(subtotal + nums[j]);
                        po.CancellationToken.ThrowIfCancellationRequested();
                        return subtotal;
                    },
                    //汇总动作
                    (x) =>
                    {
                        lock (totalLock)
                        {
                            total += x;
                        }
                    }
                );
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.WriteLine("The total is {0:N0}", total);
            Console.WriteLine("Press any key to exit");
        }

        static void Sum()
        {
            var x = new int[10000 * 10000];

            var rnd = new Random();

            Parallel.For(0, x.Length, (i) => { x[i] = rnd.Next(10); });

            var res = 0;

            var stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            Parallel.For(0, x.Length, (i) =>
            {
                //DON'T wrong caused by racing
                // res += x[i];

                Interlocked.Add(ref res, x[i]);
            });
            stopwatch.Stop();
            Console.WriteLine($"stop:{stopwatch.Elapsed.Milliseconds}");

            stopwatch.Reset();
            stopwatch.Start();
            var resRight = 0;
            foreach (var i in x)
            {
                resRight += i;
            }

            stopwatch.Stop();
            Console.WriteLine($"stop:{stopwatch.Elapsed.Milliseconds}");
            Console.WriteLine(resRight);
            Console.WriteLine(res);
        }
    }
}