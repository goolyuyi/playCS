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