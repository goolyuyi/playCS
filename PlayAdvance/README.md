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

### `using static`
using static 可用于导入单个类的静态方法
```c#
using static System.Math;
```
### switch
switch 可以有很多扩展应用

```c#
public static int SumPositiveNumbers(IEnumerable<object> sequence)
{
    int sum = 0;
    foreach (var i in sequence)
    {
        switch (i)
        {
            case 0:
                break;
            case IEnumerable<int> childSequence: //类型判别+转换
            {
                foreach(var item in childSequence)
                    sum += (item > 0) ? item : 0;
                break;
            }
            case int n when n > 0: //类型判别+转换+条件判别
                sum += n;
                break;
            case null:
                throw new NullReferenceException("Null found in sequence");
            default:
                throw new InvalidOperationException("Unrecognized type");
        }
    }
    return sum;
}
```

```c#
public static RGBColor FromRainbow(Rainbow colorBand) =>
    colorBand switch
    {
        Rainbow.Red    => new RGBColor(0xFF, 0x00, 0x00),
        Rainbow.Orange => new RGBColor(0xFF, 0x7F, 0x00),
        Rainbow.Yellow => new RGBColor(0xFF, 0xFF, 0x00),
        Rainbow.Green  => new RGBColor(0x00, 0xFF, 0x00),
        Rainbow.Blue   => new RGBColor(0x00, 0x00, 0xFF),
        Rainbow.Indigo => new RGBColor(0x4B, 0x00, 0x82),
        Rainbow.Violet => new RGBColor(0x94, 0x00, 0xD3),
        _              => throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand)),
    };
```

### ref防止拷贝:
```c#
public static ref int Find(int[,] matrix, Func<int, bool> predicate)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            if (predicate(matrix[i, j]))
                return ref matrix[i, j];
    throw new InvalidOperationException("Not found");
}
```


### default默认值
```c#
Func<string, bool> whereClause = default;
```


### readonly struct