* ArrayList vs Array vs List<T>
    * ArrayList 储存object, 动态 capacity
    * Array 储存 typed, 固定 capacity
    * List<> 储存 typed, 动态 capacity
    
* Namespace
    * alias `using Project = PC.MyCompany.Project;`
    * alias 和 global 应用`global::Symbol`
    
* `Object.ReferenceEquals` 比较对象是不是同一个(引用)
* 无论何时,应该尽量避免 ValueType [装箱](https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/types/boxing-and-unboxing)

* 对于方法来说,形参Params:定义 vs 实参Argument传入