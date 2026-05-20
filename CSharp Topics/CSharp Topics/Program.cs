
using ReflectionTopics;
using System.Reflection;
using System.Text.Json;

Type t;

Assembly a; // collection of Type


Type tp = typeof(Product);
Type ti = typeof(int);


MethodInfo[] methods = tp.GetMethods();

foreach (var method in methods)
    Console.WriteLine(method.Name);

MethodInfo myMethod = tp.GetMethod("GetDiscountedPrice");


ConstructorInfo constructor = tp.GetConstructor(new Type[] { });

PropertyInfo property = tp.GetProperty("Price");

object o = constructor.Invoke(new object[] { });

property.SetValue(o, 100);


object result = myMethod.Invoke(o, new object[] { });

Console.WriteLine(result);

