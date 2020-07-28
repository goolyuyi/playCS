### 为何尽量使用 Local Method 而不是 Lambda?
* 更清晰
* 可递归
* 避免堆内存分配,内存更少
* 更好的静态分析

* [System.Collection](https://docs.microsoft.com/zh-cn/dotnet/api/system.collections?view=netcore-3.1)
* [System.Collection.Concurrent](https://docs.microsoft.com/zh-cn/dotnet/api/system.collections.concurrent?view=netcore-3.1)

### 运算符重载
* [可重载的运算符](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/operator-overloading)
* 一般情况下都不需要重载运算符,因为非常容易有歧义,比如(Cat+Cat=神马东西?)
* 唯一要重载的情况是有明确,公认的数学意义,比如(vector+vector)
