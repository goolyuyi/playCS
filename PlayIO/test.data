# There is some code candy you should know about c#

```c#
var intArray = new int[] {1, 2, 3, 4, 5};
            
//^n last n (c# 8.0)
Console.WriteLine(intArray[^1]);
```

```c#
var intA = 111_222;//111_222
var intB = 0x111_222;//111 222 in hex
var intC = 0b1101_0010_1001;//1101 0010 1001 in binary
var longA = 111_222L;
var longB = 111_222UL;//unsigned
var longC = 0x1f_f1L;//hex
var floatA = 1.23f;//float
var doubleA = 1.23d;//double
var decimalA = 1.23m;//decimal 128 bit!
```

```c#
var strList = new List<string> {"a", "b", "5555"};
var cat = new Cat(null, secretName: "jelly") {Name = "ginger", Age = 10};
var intArray = new int[] {1, 2, 3, 4, 5};
```

```c#
//nullable
int? ni = 5;
ni = null;
Console.WriteLine(ni ?? 0); //means: if null then 0 
var c = 5 + ni; //null
Console.WriteLine(c);
```

有两个循环：
FillPipeAsync 从 Socket 读取并写入 PipeWriter。
ReadPipeAsync 从 PipeReader 读取并分析传入的行。
没有分配显式缓冲区。 所有缓冲区管理都委托给 PipeReader 和 PipeWriter 实现。 委派缓冲区管理使使用代码更容易集中关注业务逻辑。
在第一个循环中：
调用 PipeWriter.GetMemory(Int32) 从基础编写器获取内存。
调用 PipeWriter.Advance(Int32) 以告知 PipeWriter 有多少数据已写入缓冲区。
调用 PipeWriter.FlushAsync 以使数据可用于 PipeReader。
在第二个循环中，PipeReader 使用由 PipeWriter 写入的缓冲区。 缓冲区来自套接字。 对 PipeReader.ReadAsync 的调用：
返回包含两条重要信息的 ReadResult：
以 ReadOnlySequence<byte> 形式读取的数据。
布尔值 IsCompleted，指示是否已到达数据结尾 (EOF)。
找到行尾 (EOL) 分隔符并分析该行后：
该逻辑处理缓冲区以跳过已处理的内容。
调用 PipeReader.AdvanceTo 以告知 PipeReader 已消耗和检查了多少数据。
读取器和编写器循环通过调用 Complete 结束。 Complete 使基础管道释放其分配的内存。



Introduction
ASP.NET Core Identity automatically supports cookie authentication. It is also straightforward to support authentication by external providers using the Google, Facebook, or Twitter ASP.NET Core authentication packages. One authentication scenario that requires a little bit more work, though, is to authenticate via bearer tokens. I recently worked with a customer who was interested in using JWT bearer tokens for authentication in mobile apps that worked with an ASP.NET Core back-end. Because some of their customers don’t have reliable internet connections, they also wanted to be able to validate the tokens without having to communicate with the issuing server.

In this article, I offer a quick look at how to issue JWT bearer tokens in ASP.NET Core. In subsequent posts, I’ll show how those same tokens can be used for authentication and authorization (even without access to the authentication server or the identity data store).