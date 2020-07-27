* [约束器限制参考](https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters)

* 泛型实化: 对于泛化泛型`ClassName<T>` 其形参 `T` 形式化为 `int` 变成实化`ClassName<int>`
    * 对于引用类型(一切 Class)只会创建一个专版的泛型实化,减少代码量
    
* 泛型不用 boxing 和 unboxing,所以更快
    * `List<int> just ref a int value even if it's a value type`
