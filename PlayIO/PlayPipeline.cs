using System;
using System.Buffers;
using System.IO;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Tasks;

namespace playCS.PlayIO
{
    public class PlayPipeline
    {
        static async Task ReadAFile()
        {
            var blogPath = Path.GetFullPath("./PlayIO/test.data");
            var fs = new FileStream(blogPath, FileMode.Open, FileAccess.Read);
            var fsr = new StreamReader(fs);
            Console.WriteLine(await fsr.ReadLineAsync());

            fs.Seek(0, SeekOrigin.Begin);

            var p = new Pipe();

            await Task.WhenAll(ReadFromPipe(), WriteToPipe());


            //NOTE 可重用Pipe对象
            // p.Reset();

            //NOTE use stream
            https: //docs.microsoft.com/zh-cn/dotnet/standard/io/pipelines#stream-example
            var pipeReader = PipeReader.Create(fs);
            var pipeWriter =
                PipeWriter.Create(Console.OpenStandardOutput(), new StreamPipeWriterOptions(leaveOpen: true));
            //then combine two pipe here!

            //NOTE IBufferWriter,ReadOnlySequence,SequenceReader details
            // https://docs.microsoft.com/zh-cn/dotnet/standard/io/buffers#ibufferwritert

            async Task ReadFromPipe()
            {
                while (true)
                {
                    var res = await p.Reader.ReadAsync();
                    var buffer = res.Buffer;

                    while (TryReadLine(ref buffer, out ReadOnlySequence<byte> line))
                    {
                        // Process the line.
                        ProcessLine(line);
                    }

                    // Tell the PipeReader how much of the buffer has been consumed.
                    //NOTE 第一个参数是已处理到的位置
                    //NOTE 第二个参数是已观察(或预处理)的位置
                    p.Reader.AdvanceTo(buffer.Start, buffer.End);

                    // Stop reading if there's no more data coming.
                    if (res.IsCompleted)
                    {
                        break;
                    }
                }
            }

            void ProcessLine(ReadOnlySequence<byte> line)
            {
                Console.WriteLine(Encoding.UTF8.GetString(line.ToArray()));
            }

            bool TryReadLine(ref ReadOnlySequence<byte> buffer, out ReadOnlySequence<byte> line)
            {
                SequencePosition? position = buffer.PositionOf((byte) '\n');

                if (position == null)
                {
                    line = default;
                    return false;
                }

                // Skip the line + the \n.
                line = buffer.Slice(0, position.Value);
                buffer = buffer.Slice(buffer.GetPosition(1, position.Value));
                return true;
            }

            async Task WriteToPipe()
            {
                while (true)
                {
                    try
                    {
                        //NOTE get pipe's buffer
                        var mem = p.Writer.GetMemory(512);

                        var n = await fs.ReadAsync(mem);
                        if (n == 0)
                        {
                            break;
                        }

                        p.Writer.Advance(n);
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e);
                        break;
                    }

                    var flushRes = await p.Writer.FlushAsync();
                    if (flushRes.IsCompleted)
                    {
                        break;
                    }
                }

                await p.Writer.CompleteAsync();
            }
        }

        public static void Play()
        {
            ReadAFile().Wait();
        }
    }
}