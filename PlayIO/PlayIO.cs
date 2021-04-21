using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading.Channels;

namespace playCS.PlayIO
{
    public class PlayIO
    {
        public static void Play()
        {
            PlayDirectoryInfo();
            PlayFile();
            PlayPipe();
        }

        //NOTE pipe
        // https://docs.microsoft.com/zh-cn/dotnet/standard/io/pipelines

        public static void PlayPipe()
        {
            var p = Directory.GetCurrentDirectory();

            var pd = Path.GetFullPath(Path.Join(p, "../../../", "TODO.md"));
            var po = Path.GetFullPath(Path.Join(Path.GetDirectoryName(pd), "TODEL.md"));

            if (!File.Exists(pd)) throw new FileNotFoundException();

            using (var fin = File.OpenRead(pd))
            {
                using (var fou = File.Create(po))
                {
                    //connect pipe
                    fin.CopyTo(fou);
                }
            }
        }

        //NOTE filesystem use:
        // File
        // FileInfo
        // Directory
        // DirectoryInfo
        // Path

        //NOTE stream:
        // Stream : CanRead, CanWrite, CanSeek
        // FileStream
        // CryptoStream
        // NetworkStream
        // etc...

        //NOTE writer/reader: stream 操作器
        // BinaryReader/BinaryWriter
        // StringReader/StringWriter
        // etc...

        //NOTE 常见 io 操作https://docs.microsoft.com/zh-cn/dotnet/standard/io/common-i-o-tasks

        public static void PlayFile()
        {
            var p = Directory.GetCurrentDirectory();
            var pd = Path.GetFullPath(Path.Join(p, "../../../", "TODO.md"));

            if (!File.Exists(pd)) throw new FileNotFoundException();

            Span<byte> buff = stackalloc byte[8];

            using (var fs = new FileStream(pd, FileMode.Open, FileAccess.Read))
            {
                Console.WriteLine(fs.CanRead);
                fs.Read(buff);
            }

            using (var fs = new FileStream(pd, FileMode.Open))
            {
                using (var b = new StreamReader(fs))
                {
                    Console.WriteLine(b.ReadLine());
                    var res = b.ReadToEnd();
                    Console.WriteLine(res);
                }
            }
        }

        private static void PlayDirectoryInfo()
        {
            var p = Directory.GetCurrentDirectory();
            var dir = new DirectoryInfo(p);
            var pd = dir.ToString();
            pd = Path.GetFullPath(Path.Join(pd, "../../../"));
            var dird = new DirectoryInfo(pd);

            foreach (var enumerateFileSystemInfo in dird.EnumerateFileSystemInfos())
            {
                Console.WriteLine(enumerateFileSystemInfo);
            }
        }
    }
}